using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool spotFilled = false;

    public bool Spawn() //returning bool indicated whether spawning was successful or not
    {
        if (!spotFilled)
        {
            Instantiate(enemyPrefab, transform);
            spotFilled = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
