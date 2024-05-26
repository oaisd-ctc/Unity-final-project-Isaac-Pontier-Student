using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform playerTransform;
    private SpawnLocation spawnLocationScript;

    void Start()
    {
        playerTransform = Camera.main.transform;
        spawnLocationScript = transform.parent.gameObject.GetComponent<SpawnLocation>();
        Debug.Log(spawnLocationScript.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90, 0); //only rotate y
    }

    public void Death(GameObject target)
    {
        spawnLocationScript.spotFilled = false;
        Destroy(target);
        //Instantiate fire/smoke puff
    }
}
