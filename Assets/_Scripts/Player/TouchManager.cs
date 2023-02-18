using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Guide: https://youtu.be/4MOOitENQVg
// TODO: Not finished, not tested!
public class TouchManager : MonoBehaviour
{
    private PlayerInput _playerInput;

    private InputAction _touchPositionAction;
    private InputAction _touchPressAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _touchPressAction = _playerInput.actions["TouchPress"];
        _touchPositionAction = _playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        _touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        _touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext obj)
    {
        float value = obj.ReadValue<float>(); // tap status
        Vector2 position = _touchPositionAction.ReadValue<Vector2>(); // tap position
        // Debug.Log(value);
    }
}
