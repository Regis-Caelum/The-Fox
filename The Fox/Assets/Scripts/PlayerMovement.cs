using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public Joystick joystick;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
		//animator.SetBool("shooting", false);

			if (joystick.Horizontal >= .2f)
			{
				horizontalMove = runSpeed;
			}
			else if (joystick.Horizontal <= -.2f)
			{
				horizontalMove = -runSpeed;
			}
			else
			{
				horizontalMove = 0f;
			}

			float verticalMove = joystick.Vertical;

			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

			if (verticalMove >= .5f)
			{
				jump = true;
				animator.SetBool("jumping", true);
			}
			else if (verticalMove <= -.5f)
			{
				crouch = true;
				animator.SetBool("crouching", true);
			}
			else
			{
				crouch = false;
				//animator.SetBool("jumping", false);
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
			// Move our character
			controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
			jump = false;
		}
	}
