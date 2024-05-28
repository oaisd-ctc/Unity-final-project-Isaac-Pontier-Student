using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    PlayerCamera playerCamera;
    CharacterMovement characterMovement;
    PlayerInteraction playerInteraction;
    public SwordSwing swordScript;

    void Start()
    {
        playerCamera = GetComponent<PlayerCamera>();
        characterMovement = GetComponent<CharacterMovement>(); //these only work because the targeted components are on the same object as this component script!
        playerInteraction = GetComponent<PlayerInteraction>();
    }

    void Update()
    {
        HandleCameraInput();
        HandleMoveInput();
        HandleInteractionInput();
        HandleSwordInput();
        HandleJumpInput();
    }

    void HandleCameraInput()
    {
        playerCamera.AddXAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        playerCamera.AddYAxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);
    }

    void HandleMoveInput()
    {
        characterMovement.AddMoveInput(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")); //alt Input.GetAxisRaw()
        /* if (Input.GetKey(KeyCode.LeftShift))
        {
            characterMovement.moveSpeed = 9.0f;
        }
        else
        {
            characterMovement.moveSpeed = 6.0f;
        } */
    }

    void HandleInteractionInput()
    {
        if (Input.GetKey(KeyCode.Mouse1)) //when held, not clicked. Might cause problems later, but necessary for this version of the button
        {
            playerInteraction.TryInteract();
        }
    }

    void HandleSwordInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            swordScript.Attack();
        }
    }

    void HandleJumpInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            characterMovement.startJump = true;
        }
        else
        {
            characterMovement.startJump = false;
        }
    }
}
