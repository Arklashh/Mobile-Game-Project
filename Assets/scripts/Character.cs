using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Character : MonoBehaviour
{
    //Variable to store the joystick reference
    private FixedJoystick _joystick;

    //Variable to store the move speed of the character
    [SerializeField] public float MoveSpeed;

    //Variables for gravity and jumping
    [Header("Gravity & Jumping")]
    public float StickToGroundForce = 10;
    public float Gravity = 10;
    public float JumpForce = 10;

    //Variable to store the vertical velocity of the character
    private float _verticalVelocity;

    //References to the Rigidbody and Animator components
    private Rigidbody _rigidbody;
    private Animator _animator;

    //Variables for checking if the character is on the ground
    [Header("Ground Check")]
    public Transform GroundCheck;
    public LayerMask GroundLayers;
    public float GroundCheckRadius;

    //Variable to store if the character is grounded
    private bool _grounded = true;

    //Reference to the Rigidbody component
    public Rigidbody Rigidbody;

    //Start method is called when the script is initialized
    virtual protected void Start()
    {
        //Get the reference to the Rigidbody and Animator components
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _joystick = FindObjectOfType<FixedJoystick>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    //Method to get the reference to the Rigidbody component
    public Rigidbody GetRigidbody()
    {
        return Rigidbody;
    }

    //FixedUpdate method is called every fixed frame-rate frame
    virtual protected void FixedUpdate()
    {
        //Check if the character is grounded
        _grounded = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, GroundLayers);

        //Move the character based on the joystick input and move speed
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * MoveSpeed, _rigidbody.velocity.y, _joystick.Vertical * MoveSpeed);

        //If the joystick is being used, rotate the character and play the running animation
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

    //Method for handling jumping
    public void Jump()
    {
        
        //If the character is grounded, set the vertical velocity to the jump force
        if (_grounded)
        {
            _verticalVelocity = JumpForce;
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _verticalVelocity, _rigidbody.velocity.z);

        }
    }
}
