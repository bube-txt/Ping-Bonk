using UnityEngine;
using UnityEngine.InputSystem;

// Guide: https://youtu.be/4MOOitENQVg
// TODO: Not finished, not tested!
public class TouchManager : MonoBehaviour
{
    [SerializeField] GameObject cube;
    
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
        Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>()); // tap position
        position.z = cube.transform.position.z;

        cube.transform.position = position;

        // Debug.Log(value);
    }

    private void Update()
    {
        if (_touchPressAction.WasPerformedThisFrame())
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>()); // tap position
            position.z = cube.transform.position.z;

            cube.transform.position = position;
        }
    }
}
