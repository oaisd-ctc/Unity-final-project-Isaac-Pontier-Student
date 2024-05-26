using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance = 2.0f;
    private InteractionObject targetInteraction;

    // Update is called once per frame
    void Update()
    {
        targetInteraction = null;
        RaycastHit raycastHit = new RaycastHit();
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, maxDistance);
        
        if (raycastHit.collider != null)
        {
            targetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionObject>(); //does the raycastHit have an interaction script
        }
    }

    public void TryInteract()
    {
        if (targetInteraction != null) //if the targeted object does have an interaction script
        {
            targetInteraction.Interact(); //raises that object's event
        }
    }
}
