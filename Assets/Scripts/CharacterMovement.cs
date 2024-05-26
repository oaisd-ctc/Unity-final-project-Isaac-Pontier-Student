using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    public float moveSpeed;
    private Vector3 moveDirection;
    public bool startJump = false;
    float gravityValue = -20.0f;
    float yMovement = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        bool groundedPlayer = characterController.isGrounded;

        if (moveDirection.magnitude > 1.0f)//((moveDirection.z * moveDirection.z) + (moveDirection.x * moveDirection.x) > 1.0f)
        {
            moveDirection.Normalize(); //sets a max speed
        }

        if (!groundedPlayer)
        {
            //increasing gravity
            yMovement += (gravityValue * Time.deltaTime);
        }
        else
        {
            yMovement = 0.0f;
            if (startJump)
            {
                Jump();
            }
        }

        moveDirection.y = yMovement;
        moveDirection.x *= moveSpeed;
        moveDirection.z *= moveSpeed;
        characterController.Move(moveDirection * Time.deltaTime);

        //.MOVE MAKES IT CONSTANTLY ACCELERATE IN THAT DIRECTION AT THAT MAGNITUDE
        
    }


    public void AddMoveInput(float forwardInput, float rightInput) //horizontal movement
    {
        Vector3 forward = Camera.main.transform.forward; //z axis in unity
        Vector3 right = Camera.main.transform.right; //x axis in unity

        forward.y = 0.0f; //making sure you can't move down into the ground by setting the vertical directionality to 0
        right.y = 0.0f;

        forward.Normalize();
        right.Normalize();

        moveDirection = (forwardInput * forward) + (rightInput * right); //net movement direction = (forward force input * forward angle) + (sideways force input * sideways angle)
    }


    public void Jump()
    {
        yMovement = 6.0f;
    }
}
