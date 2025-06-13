using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles player movement, jumping, rotating, and shooting actions using input events.
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3.0f;
    [SerializeField] private float _rotationSpeed = 150.0f;
    [SerializeField] private float _jumpForce = 50.0f;

    public InputAction MoveAction;
    public InputAction JumpAction;
    public InputAction RotateAction;
    public InputAction ShootAction;

    private Vector2 _moveValues;
    private Vector2 _rotationValues;

    public Rigidbody _rbody;

    public bool _isGrounded = true;

    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _moveValues = MoveAction.ReadValue<Vector2>();
        _rotationValues = RotateAction.ReadValue<Vector2>();

        if (JumpAction.ReadValue<float>() == 1 && _isGrounded)
        {
            _rbody.AddRelativeForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }

        if (ShootAction.ReadValue<float>() == 1)
        {
            BroadcastMessage("Shoot", SendMessageOptions.DontRequireReceiver);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _movementSpeed * Time.fixedDeltaTime * _moveValues.y);
        transform.Translate(Vector3.left * _movementSpeed * Time.fixedDeltaTime * -_moveValues.x);
        transform.Rotate(Vector3.up, _rotationSpeed * Time.fixedDeltaTime * _rotationValues.x);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    public void OnEnable()
    {
        MoveAction.Enable();
        JumpAction.Enable();
        RotateAction.Enable();
        ShootAction.Enable();
    }

    private void OnDisable()
    {
        MoveAction.Disable();
        JumpAction.Disable();
        RotateAction.Disable();
        ShootAction.Disable();
    }
}
