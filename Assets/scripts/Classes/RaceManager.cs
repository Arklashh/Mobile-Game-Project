using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Character
{
    public float NewMoveSpeed = 6f;

    protected override void FixedUpdate()
    {
        MoveSpeed = NewMoveSpeed;
    }
}

public class Dwarf : Character
{
    public float newJumpHeight = 15f;

    protected override void FixedUpdate()
    {
        //jumpHeight = newJumpHeight;
    }
}

public class Robot : Character
{
    public float newMoveSpeed = 10f;
    public float newJumpHeight = 20f;

    protected override void FixedUpdate()
    {
        //moveSpeed = newMoveSpeed;
        //jumpHeight = newJumpHeight;
    }
}
