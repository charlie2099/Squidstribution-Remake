using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementForce = 1.0f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private Vector3 forceDir = Vector3.zero;
    [SerializeField] private Camera playerCamera;
    
    private PlayerInputActions _playerInputActions;
    private InputAction _movement;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        _playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _playerInputActions.Player.LightAttack.started += DoLightAttack;
        _playerInputActions.Player.HeavyAttack.started += DoHeavyAttack;
        _playerInputActions.Player.Dash.started += DoDash;
        _playerInputActions.Player.Dash.canceled += StopDash;
        _movement = _playerInputActions.Player.Move;
        _playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Player.LightAttack.started -= DoLightAttack;
        _playerInputActions.Player.HeavyAttack.started -= DoHeavyAttack;
        _playerInputActions.Player.Dash.started -= DoDash;
        _playerInputActions.Player.Dash.canceled -= StopDash;
        _playerInputActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        forceDir += _movement.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDir += _movement.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;
        
        _rigidbody.AddForce(forceDir, ForceMode.Impulse);
        forceDir = Vector3.zero; // So the character comes to a stop immediately after receiving no more input

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed) // sqrMagnitude is a less expensive op 
        {
            _rigidbody.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * _rigidbody.velocity.y;
        }
        
        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = _rigidbody.velocity;
        direction.y = 0f;

        if (_movement.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            _rigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private Vector3 GetCameraRight(Camera camera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    
    private Vector3 GetCameraForward(Camera camera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }
    
    private void DoLightAttack(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("lightattack");
    }
    
    private void DoHeavyAttack(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("heavyattack");
    }
    
    private void DoDash(InputAction.CallbackContext obj)
    {
        movementForce = 6;
        maxSpeed = 20;
    }
    
    private void StopDash(InputAction.CallbackContext obj)
    {
        movementForce = 3;
        maxSpeed = 10;
    }
}
