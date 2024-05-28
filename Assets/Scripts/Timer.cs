using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //public UnityEvent changeTexture = new UnityEvent();
    private float timer;
    public Material firstDigitMaterial;
    public Material secondDigitMaterial;
    public Texture[] textures = new Texture[10];

    public SpawnLocation location1;
    public SpawnLocation location2;
    public SpawnLocation location3;
    public SpawnLocation location4;

    [SerializeField] private EscapeDoor escapeDoorScript;

    [SerializeField] private Collider buttonCollider;


    // Start is called before the first frame update
    void Start()
    {
        //this is just ResetTimer but without spawning an enemy
        timer = 30.99f; 
        firstDigitMaterial.SetTexture("_MainTex", textures[3]);
        secondDigitMaterial.SetTexture("_MainTex", textures[0]);
    }

    // Update is called once per frame
    void Update()
    {
        int onesPlace = Convert.ToInt32(Math.Truncate(timer));
        onesPlace = onesPlace % 10;

        timer -= Time.deltaTime; //realtime timer
        if (timer >= 30)
        {
            firstDigitMaterial.SetTexture("_Maintex", textures[3]);
        }
        else if (timer < 30 && timer >= 20)
        {
            firstDigitMaterial.SetTexture("_MainTex", textures[2]);
        }
        else if (timer < 20 && timer >= 10)
        {
            firstDigitMaterial.SetTexture("_MainTex", textures[1]);
        }
        else if (timer < 10 && timer > 0)
        {
            firstDigitMaterial.SetTexture("_MainTex", textures[0]);
        }
        else //timer runs out
        {
            //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); //returns an array
            
            if (location1.spotFilled)
            {
                location1.Kill();
            }
            if (location2.spotFilled)
            {
                location2.Kill();
            }
            if (location3.spotFilled)
            {
                location3.Kill();
            }
            if (location4.spotFilled)
            {
                location4.Kill();
            }

            escapeDoorScript.OpenDoor(); //open door
            buttonCollider.enabled = false; //lock button
        }

        if (9 >= onesPlace && onesPlace >= 0) //update ones place
        {
            secondDigitMaterial.SetTexture("_MainTex", textures[onesPlace]);
        }
    }

    public void ResetTimer()
    {
        timer = 30.99f; //to display the three-zero digits too
        firstDigitMaterial.SetTexture("_MainTex", textures[3]);
        secondDigitMaterial.SetTexture("_MainTex", textures[0]);
        
        if (!location1.Spawn())
        {
            if (!location2.Spawn())
            {
                if (!location3.Spawn())
                {
                    location4.Spawn();
                }
            }
        }
    }
}
