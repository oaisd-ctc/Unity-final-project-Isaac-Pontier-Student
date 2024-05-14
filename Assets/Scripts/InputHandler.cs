using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    PlayerCamera playerCamera;
    CharacterMovement characterMovement;
    //PlayerInteraction playerInteraction;

    void Start()
    {
        playerCamera = GetComponent<PlayerCamera>();
        characterMovement = GetComponent<CharacterMovement>();
        //playerInteraction = GetComponent<>();
    }

    void Update()
    {
        HandleCameraInput();
        HandleMoveInput();
        //HandleInteractionInput();
    }

    void HandleCameraInput()
    {
        playerCamera.AddXAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        playerCamera.AddYAxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);
    }

    void HandleMoveInput()
    {
        characterMovement.AddMoveInput
    }
}
