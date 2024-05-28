using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    MeshFilter doorMeshFilter;
    public Mesh openDoorMesh; //assigned in editor
    private Collider doorCollider;
    //public GameManager gameManager;

    void Start()
    {
        doorMeshFilter = GetComponent<MeshFilter>();
        doorCollider = GetComponent<Collider>();
    }

    public void OpenDoor()
    {
        doorMeshFilter.sharedMesh = openDoorMesh;
        doorCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>() != null)
        {
            GameManager.LoadScene("TitleScreen");
        }
    }
}
