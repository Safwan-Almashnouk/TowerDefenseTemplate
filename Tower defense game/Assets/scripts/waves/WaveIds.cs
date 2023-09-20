using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveIds : MonoBehaviour
{
    public GameObject enemyName;
    public int amount;
    public float spacing;
    public float delay;
   
    internal WaveIds(GameObject enemyName, int amount, float spacing, float delay) 
    { 
        this.enemyName = enemyName; 
        this.amount = amount;
        this.spacing = spacing;
        this.delay = delay;
    }

}
