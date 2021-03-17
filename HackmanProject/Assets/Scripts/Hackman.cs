using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackman : BaseGridMovement
{
    protected override void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            currentInputDirection = new IntVector2(0, 1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            currentInputDirection = new IntVector2(0, -1);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            currentInputDirection = new IntVector2(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentInputDirection = new IntVector2(1, 0);
        }
        base.Update();

    }
}
