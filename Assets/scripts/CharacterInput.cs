using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//This script handles the input for the Character class.
public class CharacterInput : MonoBehaviour
{
    //Joystick input
    private FixedJoystick _joystick;
    //Character component
    private Character _character;

    //Initialize the joystick and character components
    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();
        _character = GetComponent<Character>();
    }

    private void FixedUpdate()
    {
        //Move the character based on joystick input
        _character.GetRigidbody().velocity = new Vector3(_joystick.Horizontal * _character.MoveSpeed, _character.GetRigidbody().velocity.y, _joystick.Vertical * _character.MoveSpeed);

    }

    //Call the Jump method on the Character component when the jump button is pressed.
    public void OnJumpButtonPressed()
    {
        _character.Jump();
    }
}

