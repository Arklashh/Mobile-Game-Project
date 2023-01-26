using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Character : MonoBehaviour
{
    private FixedJoystick _joystick;

    [SerializeField] public float MoveSpeed;

    [Header("Gravity & Jumping")]
    public float StickToGroundForce = 10;
    public float Gravity = 10;
    public float JumpForce = 10;

    private float _verticalVelocity;
    private Rigidbody _rigidbody;
    private Animator _animator;

    [Header("Ground Check")]
    public Transform GroundCheck;
    public LayerMask GroundLayers;
    public float GroundCheckRadius;

    private bool _grounded;

    public Rigidbody Rigidbody;

    virtual protected void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _joystick = FindObjectOfType<FixedJoystick>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigidbody()
    {
        return Rigidbody;
    }

    virtual protected void FixedUpdate()
    {
        _grounded = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, GroundLayers);

        _rigidbody.velocity = new Vector3(_joystick.Horizontal * MoveSpeed, _rigidbody.velocity.y, _joystick.Vertical * MoveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    public void OnJumpButtonPressed()
    {
        _verticalVelocity = JumpForce;
    }

    private void Update()
    {
        Jump();
        OnJumpButtonPressed();
    }

    public void Jump()
    {
        if (_grounded)
        {
            _verticalVelocity = JumpForce;
        }

        if (_grounded && _verticalVelocity <= 0)
        {
            _verticalVelocity = -StickToGroundForce * Time.deltaTime;
        }
        else
        {
            _verticalVelocity -= Gravity * Time.deltaTime;
        }
    }
}
