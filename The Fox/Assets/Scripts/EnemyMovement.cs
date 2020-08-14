using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;

    public CharacterController2D controller;

    public int movementrange = 10;

    int counter = 0;

    public float speed = 40f;

    /*void Update()
    {
        if(counter == movementrange)
        {
            counter = -counter;
        }
        if(counter < movementrange && counter > 0)
            counter += 1;
        if (counter < 0)
            counter++;
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter == movementrange)
        {
            counter = -counter;
        }
        if (counter < movementrange && counter >= 0)
        {
            counter += 1;
            float runspeed = -speed;
            controller.Move(runspeed * Time.fixedDeltaTime, false, false);
        }
        if (counter < 0)
        {
            float runspeed = speed;
            controller.Move(runspeed * Time.fixedDeltaTime, false, false);
            ++counter;
        }
    }
}
