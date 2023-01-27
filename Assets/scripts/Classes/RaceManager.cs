using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Human class inherits from the Character class and overrides the MoveSpeed property.
public class Human : Character
{
    // NewMoveSpeed is the new MoveSpeed for the Human character.
    public float NewMoveSpeed = 10f;

    // Overrides the FixedUpdate method from the Character class.
    protected override void FixedUpdate()
    {
        // Set the MoveSpeed of the Human character to NewMoveSpeed.
        MoveSpeed = NewMoveSpeed;
    }
}

// Dwarf class inherits from the Character class and overrides the MoveSpeed property.
public class Dwarf : Character
{
    // newMoveSpeed is the new MoveSpeed for the Dwarf character.
    public float newMoveSpeed = 6f;

    // Overrides the FixedUpdate method from the Character class.
    protected override void FixedUpdate()
    {
        // Set the MoveSpeed of the Dwarf character to newMoveSpeed.
        MoveSpeed = newMoveSpeed;
    }
}

// Robot class inherits from the Character class and overrides the MoveSpeed property.
public class Robot : Character
{
    // newMoveSpeed is the new MoveSpeed for the Robot character.
    public float newMoveSpeed = 15f;

    // Overrides the FixedUpdate method from the Character class.
    protected override void FixedUpdate()
    {
        // Set the MoveSpeed of the Robot character to newMoveSpeed.
        MoveSpeed = newMoveSpeed;
    }
}

