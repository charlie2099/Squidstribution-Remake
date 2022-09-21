using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementForce = 1.0f;
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private Camera playerCamera;
    
        private PlayerInputActions _playerInputActions;
        private InputAction _movement;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private Transform _target;
        private Vector3 _forceDir = Vector3.zero;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _playerInputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _movement = _playerInputActions.Player.Move;
            _playerInputActions.Player.LightAttack.started += DoLightAttack;
            _playerInputActions.Player.HeavyAttack.started += DoHeavyAttack;
            _playerInputActions.Player.SpinAttack.started += DoSpinAttack;
            _playerInputActions.Player.InkBlast.started += DoInkBlast;
            _playerInputActions.Player.Pickup.started += DoPickup;
            _playerInputActions.Player.Drop.started += DoDrop;
            _playerInputActions.Player.Throw.started += DoThrow;
            _playerInputActions.Player.Dash.started += DoDash;
            _playerInputActions.Player.Dash.canceled += StopDash;
            _playerInputActions.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInputActions.Player.LightAttack.started -= DoLightAttack;
            _playerInputActions.Player.HeavyAttack.started -= DoHeavyAttack;
            _playerInputActions.Player.SpinAttack.started -= DoSpinAttack;
            _playerInputActions.Player.InkBlast.started -= DoInkBlast;
            _playerInputActions.Player.Pickup.started -= DoPickup;
            _playerInputActions.Player.Drop.started -= DoDrop;
            _playerInputActions.Player.Throw.started -= DoThrow;
            _playerInputActions.Player.Dash.started -= DoDash;
            _playerInputActions.Player.Dash.canceled -= StopDash;
            _playerInputActions.Player.Disable();
        }

        private void Update()
        {
            var startPos = transform.position + Vector3.up; // slight offset from the floor
            var endPos = startPos + transform.TransformDirection(Vector3.forward) * 5;
            Debug.DrawLine(startPos, endPos , Color.magenta);

            /*if (_target == null)
            {
                return;
            }
            var target = _target;
            var dirToTarget = Vector3.Normalize(target.position - transform.position);
            var dot = Vector3.Dot(transform.forward, dirToTarget);

            var behind = dot < -0.707;
            var inFront = dot > 0.707;

            if (dot < 0/*behind#1#)
            {
                Debug.Log("BEHIND");
                Debug.DrawLine(transform.position, _target.position, Color.red);
            }
            else if (dot > 0/*inFront#1#)
            {
                Debug.Log("IN FRONT");
                Debug.DrawLine(transform.position, target.position, Color.green);
            }*/
        }

        private void FixedUpdate()
        {
            _forceDir += _movement.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
            _forceDir += _movement.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;
        
            _rigidbody.AddForce(_forceDir, ForceMode.Impulse);
            _forceDir = Vector3.zero; // So the character comes to a stop immediately after receiving no more input

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

        #region InputActions
        private void DoLightAttack(InputAction.CallbackContext obj)
        {
            _animator.SetTrigger("lightattack");
        }
    
        private void DoSpinAttack(InputAction.CallbackContext obj)
        {
            _animator.SetTrigger("spinattack");
        }
    
        private void DoInkBlast(InputAction.CallbackContext obj)
        {
            _animator.SetTrigger("inkblast");
        }
        
        private void DoPickup(InputAction.CallbackContext obj)
        {
            // Calculate the Dot product to check if an object is front
            // of the player

            /*var startPos = transform.position + Vector3.up; // slight offset from the floor
            var endPos = transform.TransformDirection(Vector3.forward);

            RaycastHit hit;
            if (Physics.Raycast(startPos, endPos, out hit, 5.0f))
            {
                if (hit.transform.GetComponent<IPickupable>() != null) 
                {
                    hit.transform.GetComponent<IPickupable>().Pickup(gameObject);
                    _target = hit.transform;
                }
            }*/
        }
        
        private void DoDrop(InputAction.CallbackContext obj)
        {
            /*_target.GetComponent<IPickupable>().Drop();*/
        }
    
        private void DoThrow(InputAction.CallbackContext obj)
        {
            _animator.SetTrigger("throw");
            /*_target.GetComponent<IPickupable>().Drop();
            _target.GetComponent<Rigidbody>().AddForce(Vector3.forward * 50, ForceMode.Impulse);*/
        }
    
        private void DoHeavyAttack(InputAction.CallbackContext obj)
        {
            _animator.SetTrigger("heavyattack");
        }
    
        private void DoDash(InputAction.CallbackContext obj)
        {
            movementForce = 6;
            maxSpeed = 20;
            // TODO: Inflict damage whilst dashing (if object noticeably smaller than the player)
        }
    
        private void StopDash(InputAction.CallbackContext obj)
        {
            movementForce = 3;
            maxSpeed = 10;
        }
        #endregion
    }
}
