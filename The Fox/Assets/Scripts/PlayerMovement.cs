using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Joystick joystick;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    
    bool jump = false;

    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        if(joystick.Horizontal >= 0.2f)
        {
            horizontalMove = joystick.Horizontal;
        }else if(joystick.Horizontal <= -0.2f)
        {
            horizontalMove = joystick.Horizontal*runSpeed;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (joystick.Vertical >= 0.5f)
        {
            jump = true;
            animator.SetBool("jumping", true);
        }else if(joystick.Vertical <= -0.5f)
        {
            crouch = true;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("jumping", false);
    }

    public void OnCrouching(bool crouching)
    {
        animator.SetBool("crouching", crouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime, crouch, jump);
    }
}
