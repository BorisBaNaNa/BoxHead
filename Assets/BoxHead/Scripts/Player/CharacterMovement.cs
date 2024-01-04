using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour, IPushable
{
    public Vector3 Velocity => _velocity;

    [Header("Components")]
    [SerializeField] private CharacterController _characterController;

    [Header("Movement stats")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCastDistance = 0.01f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _velocitySmoothOnGround = 0.05f;
    [SerializeField] private float _velocitySmoothOnAir = 0.2f;

    [Header("Jump stats")]
    [SerializeField] private float _maxJumpTime = 1f;
    [SerializeField] private float _maxJumpHeight = 1.25f;
    [SerializeField] private float _minDurForJump = 0.06f;
    [SerializeField] private float _maxDurForJump = 0.5f;

    private bool IsJumping => _velocity.y > 0.0001f;
    private bool IsFalling => _velocity.y < 0.0001f;

    private PlayerInputActions _inputActions;
    private Vector3 _velocity;
    private Vector3 _curAxeleration;
    private float _gravityForce;
    private float _maxStartJumpVelocity;
    private float _minStartJumpVelocity;
    private bool _isGrounded;

    [Inject]
    public void Construct(PlayerInputActions inputActions)
    {
        _inputActions = inputActions;
    }

    private void Awake()
    {
        InputInit();
        CalculateGravityParams();
    }

    private void OnDestroy()
    {
        DeactiveInputs();
    }

    private void Update()
    {
        GroundedCheck();
        ApplyMoveInput();
        ApplyGravity();

        MoveCharacter(_velocity);
    }

    private void OnValidate()
    {
        if (_characterController == null)
            _characterController = GetComponent<CharacterController>();
    }

    public void Push(Vector3 force)
    {
        _velocity += force;
    }

    private void InputInit()
    {
        _inputActions.Player.Movement.Enable();
        _inputActions.Player.Jump.Enable();
        _inputActions.Player.Jump.performed += Jump;
    }

    private void DeactiveInputs()
    {
        _inputActions.Player.Movement.Disable();
        _inputActions.Player.Jump.Disable();
        _inputActions.Player.Jump.performed -= Jump;
    }

    private void ApplyMoveInput()
    {
        Vector3 InputDir = _inputActions.Player.Movement.ReadValue<Vector3>();
        Vector3 horizontalVelocity = InputDir * _speed;
        horizontalVelocity.y = _velocity.y;
        float smoothTime = _isGrounded ? _velocitySmoothOnGround : _velocitySmoothOnAir;
        _velocity = Vector3.SmoothDamp(_velocity, horizontalVelocity, ref _curAxeleration, smoothTime);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (!_isGrounded) return;
        float t = Mathf.InverseLerp(_minDurForJump, _maxDurForJump, (float)context.duration);
        float jumpVelocity = Mathf.Lerp(_minStartJumpVelocity, _maxStartJumpVelocity, t);
        _velocity.y = jumpVelocity;
    }

    private void ApplyGravity()
    {
        if (!IsJumping && _isGrounded)
            _velocity.y = 0;
        else
            _velocity.y -= _gravityForce * Time.deltaTime;
    }

    private void MoveCharacter(Vector3 movement)
    {
        if (movement == Vector3.zero) return;

        _characterController.Move(movement * Time.deltaTime);
    }

    private void CalculateGravityParams()
    {
        float maxHeightTime = _maxJumpTime * 0.5f;
        _gravityForce = (2 * _maxJumpHeight) / Mathf.Pow(maxHeightTime, 2);

        var startJumpVelocity = 2 * _maxJumpHeight / maxHeightTime;
        _minStartJumpVelocity = startJumpVelocity * 0.5f;
        _maxStartJumpVelocity = startJumpVelocity * 1.5f;
    }

    private void GroundedCheck()
    {
        Vector3 checkPos = transform.position;
        checkPos.y -= _characterController.height * 0.5f - _characterController.radius + _groundCastDistance;
        _isGrounded = Physics.CheckSphere(checkPos, _characterController.radius, _groundLayer.value);
    }
}
