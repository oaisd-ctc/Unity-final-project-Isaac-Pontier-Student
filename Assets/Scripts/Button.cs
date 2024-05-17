using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Vector3 upPosition;
    private Vector3 downPosition;
    private Timer timerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        timerScript = GetComponent<Timer>(); //why is this not finding the component
        upPosition = transform.position;
        downPosition = new Vector3(0.00f, 1.19f, -1.10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            timerScript.ResetTimer();
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            transform.position = downPosition;
        }
        else
        {
            transform.position = upPosition;
        }
    }
}
