using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour
{
    public UnityEvent interactionEvent = new UnityEvent();

    public void Interact()
    {
        interactionEvent.Invoke(); 
    }
}
