using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Vector3 upPosition;
    private Vector3 downPosition;
    [SerializeField] private Timer timerScript;
    [SerializeField] private PlayerInteraction playerInteractionScript;
    //These need to be set in the editor because getComponent<>() only gets the component FROM THE SAME GAMEOBJECT THIS SCRIPT IS ATTACHED TO

    // Start is called before the first frame update
    void Start()
    {
        upPosition = transform.position;
        downPosition = new Vector3(0.00f, 1.19f, -1.10f);
    }

    void Update()
    {
        transform.position = upPosition;
    }

    //!! Buttonpress can only run while you're looking at it and holding the key
    public void ButtonPress()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) //only goes when the key is clicked at start while looking at button
        {
            timerScript.ResetTimer(); //this needs to be done once without using any Input in order to fix all problems
            //problem is that if you start by clicking off of it, it won't reset timer but it will lower the button. Need to trigger reset once then this downPosition BS
        }
        transform.position = downPosition;

        // Need to trigger Reset whenever ButtonPress is active, but it only triggers once before buttonpress stops running
    }
}