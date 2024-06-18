using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;   // reference to the CharacterController component attached to the player

    public float walkspeed = 6f;
    public float sprintSpeed = 11f;
    public float gravity = -18.81f * 2;   // gravity force applied to the player
    public float jumpHeight = 3f;         // height the player can jump

    public Transform groundCheck;         // check if the player is on the ground
    public float groundDistance = 0.4f;   // radius of the ground check sphere
    public LayerMask groundMask;          // to specify what layers count as ground

    public KeyCode sprintKey = KeyCode.LeftShift;   //  key used to trigger sprinting

    Vector3 velocity;        // stores the player's velocity

    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;     // resets the vertical velocity when the player is grounded
        }

        float x = Input.GetAxis("Horizontal");  // the input for horizontal and vertical movement
        float z = Input.GetAxis("Vertical");

        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetKey(sprintKey) & isGrounded)
            controller.Move(move * sprintSpeed * Time.deltaTime);
        else if(!Input.GetKey(sprintKey) | !isGrounded)               // "|" is logical OR !!!!! not conditional
            controller.Move(move * walkspeed * Time.deltaTime);

        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;             // applies gravity to the player's vertical velocity

        controller.Move(velocity * Time.deltaTime);         // moves the player based on the current velocity
    }
}
