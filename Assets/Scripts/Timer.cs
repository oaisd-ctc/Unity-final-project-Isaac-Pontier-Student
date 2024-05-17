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

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
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
        else
        {
            //ResetTimer();
            Debug.Log("timer expire");
        }

        secondDigitMaterial.SetTexture("_MainTex", textures[onesPlace]);
    }

    public void ResetTimer()
    {
        timer = 31.0f; //to display the three-zero digits too
        firstDigitMaterial.SetTexture("_MainTex", textures[3]);
        secondDigitMaterial.SetTexture("_MainTex", textures[0]);
    }
}
