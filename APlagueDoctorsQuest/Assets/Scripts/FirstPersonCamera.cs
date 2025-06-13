using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles the camera rotation based on player input, with constraints on vertical rotation angles.
/// </summary>

public class FirstPersonCamera : MonoBehaviour
{
    // Serialized private fields for Unity Inspector
    [SerializeField] private float _rotationSpeed = 50.0f;
    [SerializeField] private Vector2 _rotationValues;

    // Public input action for reading rotation input
    public InputAction RotationAction;

    // Camera's rotation angles (x, y, z)
    private Vector3 _cameraAngles;

    // Minimum and maximum vertical angles for rotation
    private const float MinVerticalAngle = 15.0f;
    private const float MaxVerticalAngle = 325.0f;


    private void Update()
    {
        _rotationValues = RotationAction.ReadValue<Vector2>();

        _cameraAngles = transform.localRotation.eulerAngles;

        if (_cameraAngles.x > MinVerticalAngle && _cameraAngles.x < 180)
        {
            transform.localRotation = Quaternion.Euler(MinVerticalAngle, 0, 0);
        }
        if (_cameraAngles.x > 180 && _cameraAngles.x < MaxVerticalAngle)
        {
            transform.localRotation = Quaternion.Euler(MaxVerticalAngle, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.left, _rotationSpeed * Time.fixedDeltaTime * _rotationValues.y);
    }

    private void OnEnable()
    {
        RotationAction.Enable();
    }

    private void OnDisable()
    {
        RotationAction.Disable();
    }
}
