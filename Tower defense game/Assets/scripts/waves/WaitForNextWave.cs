using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForNextWave : MonoBehaviour
{
    public float delay;
    public spawning spawnScript;
   internal IEnumerator WaitForWave()
    {
        GlobalData.WaveIndex++;
        yield return new WaitForSeconds(delay);
        StartCoroutine(spawnScript.Spawning());
        Debug.Log("hasWaited");
    }

    private void Start()
    {
        spawnScript = GetComponent<spawning>();
    }
}
