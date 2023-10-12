using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoises : MonoBehaviour
{

    public AudioClip Roar;
    public AudioSource audio;
   

    void Start()
    {
        float chance = Random.RandomRange(0, 2);
        if(chance >= 1)
        {
            audio.PlayOneShot(Roar);
        }
       
    }

}
