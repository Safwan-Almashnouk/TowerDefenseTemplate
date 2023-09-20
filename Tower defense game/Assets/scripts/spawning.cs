using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public Transform[] spawnpos; 
    public int selector;
    public GameObject[] enemies; 
    public bool Attackstate = true;
    public WaveStructure waveData;
    
    void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while (Attackstate == true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 0.8f));
            for (int i = 0; i < waveData.waveDataList.Count; i++)
            {
                yield return new WaitForSeconds(waveData.waveDataList[i].delay);
                StartCoroutine(SpawnWaveData(waveData.waveDataList[i]));
            }
          
        }


    }
    private IEnumerator SpawnWaveData(WaveData data)
    {
        for (int i = 0; i < data.amount; i++)
        {
            int chosenIndex = Random.Range(0, 2);
            Transform spawnedEnemy = Instantiate(enemies[(int)data.id].transform, spawnpos[chosenIndex].position, Quaternion.identity);
            spawnedEnemy.GetComponent<Move>().Lane = GameObject.Find("Waypoint Manager").GetComponent<LanesScript>().lanes[chosenIndex];
            yield return new WaitForSeconds(data.spacing);
        }
    }

    public static ScriptableObject CreateInstance(WaveData waveData)
    {
        
        waveData = new WaveData();
        return Instantiate(waveData);
    }
  
    void Update()
    {
        
    }
}
