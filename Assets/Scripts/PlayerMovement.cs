using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float sprintMultiplyer = 2f;
    public float gravity = -20f;
    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 2f;

    Vector3 velocity;
    bool isTouchingGround;
    bool canJump = true;

    // Update is called once per frame
    void Update()
    {
        //Check if player is touching the ground to determine when to stop falling
        isTouchingGround = controller.isGrounded;
        if(isTouchingGround && velocity.y < 0)
            {
                velocity.y = -2f;
                canJump = true;
            }

        //Get movement inputs, horizontal is left and right, vertical is forward and backward
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Move the player based on input
        Vector3 move = transform.right * x + transform.forward * z;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * speed * sprintMultiplyer * Time.deltaTime);
            Debug.Log("Sprinting");
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump"))
        {
            if (isTouchingGround && canJump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                canJump = false;
                Debug.Log("Jumped");
            }
            else if(!isTouchingGround)
            {
                Debug.Log("Jump blocked - in air");
            }
        }

        //Have the player fall due to gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
