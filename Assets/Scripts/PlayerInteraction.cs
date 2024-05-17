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
            targetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionObject>();
        }
        if (targetInteraction && Input.GetKeyDown(KeyCode.Mouse0)) //could also check here if it's enabled, but I'm not worrying about a progression lock yet
        {
            targetInteraction.Interact();
            
        }
    }
}
