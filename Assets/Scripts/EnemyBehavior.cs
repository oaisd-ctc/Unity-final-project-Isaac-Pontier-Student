using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform playerTransform;
    //public SpawnLocation spawnLocationScript;
    public int enemyHealth = 3;

    void Start()
    {
        playerTransform = Camera.main.transform;
        //spawnLocationScript = transform.parent.gameObject.GetComponent<SpawnLocation>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90, 0); //only rotate y
    }

    //using a Death() function built in here leads to null reference exception where spawnLocationScript is not null in update or start but it only becomes null here
    //might be because this script is initially on a prefab that is not a child of anything, where we need to access the parent (and SpawnLocation) of the INSTANCES
}
