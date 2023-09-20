using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaveData : ScriptableObject
{
    public EnumEnemy id;
    public int amount;
    public float spacing;
    public float delay;
}
