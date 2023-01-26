using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    private FixedJoystick _joystick;
    private Character _character;

    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();
        _character = GetComponent<Character>();
    }

    private void FixedUpdate()
    {
        _character.GetRigidbody().velocity = new Vector3(_joystick.Horizontal * _character.MoveSpeed, _character.GetRigidbody().velocity.y, _joystick.Vertical * _character.MoveSpeed);

    }

    public void OnJumpButtonPressed()
    {
        _character.Jump();
    }
}
