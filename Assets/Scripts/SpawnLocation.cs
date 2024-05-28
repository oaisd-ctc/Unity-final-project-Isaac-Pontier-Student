using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public bool spotFilled = false;

    public GameObject enemyPrefab;
    private EnemyBehavior instantiatedEnemyScript;
    private GameObject currentEnemyHere;
    
    public GameObject explosionPrefab;
    private GameObject instantiatedExplosion;
    
    public GameObject damageSpark;
    private GameObject instantiatedDamageSpark;

    public bool Spawn() //returning bool indicated whether spawning was successful or not
    {
        if (!spotFilled)
        {
            currentEnemyHere = Instantiate(enemyPrefab, transform);
            spotFilled = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Damage() //"GameObject target" as an argument
    {
        instantiatedEnemyScript = currentEnemyHere.GetComponent<EnemyBehavior>();
         if (instantiatedEnemyScript.enemyHealth > 1)
         {
                instantiatedEnemyScript.enemyHealth--;
                instantiatedDamageSpark = Instantiate(damageSpark, transform);
                Destroy(instantiatedDamageSpark, 1.0f);
         }
         else
         {
             Kill(); //used as a seperate function so that I can instantly kill them all at the end
         }
    }

    public void Kill() //"GameObject target, Transform explosionLocation" as past arguments used
    {
         Destroy(currentEnemyHere);
         instantiatedExplosion = Instantiate(explosionPrefab, transform);
         Destroy(instantiatedExplosion, 1.7f); //second argument is a float that tells it how long to wait before destroying
         spotFilled = false;
         currentEnemyHere = null;
    }
}
