using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Character
{
    public float NewMoveSpeed = 10f;

    protected override void FixedUpdate()
    {
        MoveSpeed = NewMoveSpeed;
    }
}

public class Dwarf : Character
{
    public float newMoveSpeed = 6f;

    protected override void FixedUpdate()
    {
        MoveSpeed = newMoveSpeed;
    }
}

public class Robot : Character
{
    public float newMoveSpeed = 15f;

    protected override void FixedUpdate()
    {
        MoveSpeed = newMoveSpeed;
    }
}
