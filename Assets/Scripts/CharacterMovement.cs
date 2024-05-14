using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    public float moveSpeed = 5.0f;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.Normalize();
        moveDirection.y = -1.0f; //gravity force

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void AddMoveInput(float forwardInput, float rightInput) //this needs to be configured in inputhandler
    {
        Vector3 forward = Camera.main.transform.forward; //z axis in unity
        Vector3 right = Camera.main.transform.right; //x axis in unity

        forward.y = 0f; //making sure you can't move down into the ground by setting the vertical directionality to 0
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        moveDirection = (forwardInput * forward) + (rightInput * right); //net movement direction = (forward force input * forward angle) + (sideways force input * sideways angle)
    }
}
