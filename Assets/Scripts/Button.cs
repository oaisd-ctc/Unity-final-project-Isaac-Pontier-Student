using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Vector3 upPosition;
    private Vector3 downPosition;
    [SerializeField] private Timer timerScript;
    private Button buttonScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //timerScript = GetComponent<Timer>(); //why is this not finding the component
        upPosition = transform.position;
        downPosition = new Vector3(0.00f, 1.19f, -1.10f);
        buttonScript = GetComponent<Button>();
    }

    void OnEnable()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (buttonScript.enabled == true)
        {
            timerScript.ResetTimer();
            if(Input.GetKey(KeyCode.Mouse0))
            {
            transform.position = downPosition;
            }
            else
            {
                transform.position = upPosition;
                buttonScript.enabled = false;
            }
        }
        
    }

    //new plan: enable/disable button script when interactionobject event is triggered, then have the button script handle up/down and reset
}