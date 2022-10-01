using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    //[SerializeField] private Camera camera;
    
    //private PlayerInputActions _playerInputActions;
    //private InputAction _cameraLook;
    //private Vector2 lastPoint;
    
    //private void Awake() => _playerInputActions = new PlayerInputActions();

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        //_cameraLook = _playerInputActions.Player.Look;
       // _cameraLook.performed += OnPoint;
        //_playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        //_cameraLook.performed -= OnPoint;
        //_playerInputActions.Player.Disable();
    }

    /*private void OnPoint(InputAction.CallbackContext ctx) {
        // obtain current mouse position from context
        Vector2 screenPoint = ctx.ReadValue<Vector2>();
        // convert it from screen to world coordinates
        Vector2 worldPoint = camera.ScreenToWorldPoint(screenPoint);
        // check if middle mouse button is being held. 
        if (_cameraLook.ReadValue<float>() > 0) {
            // calculate difference between current and previous mouse location
            Vector2 delta = lastPoint - worldPoint;
            // use that difference to move your camera
            transform.Translate(delta);
            // adjust the worldPoint accordingly, because after the scroll it's now somewhere else
            worldPoint += delta;
        }
        // update lastPoint for the next frame
        lastPoint = worldPoint;
    }*/
}
