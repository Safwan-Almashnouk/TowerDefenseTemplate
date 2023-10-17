using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public Transform[] spawnpos; 
    public int selector;
    public GameObject[] enemies; 
    public WaveStructure[] waveData;
    public SoundManager soundManager;
    public WaitForNextWave wait;
    
    
    void Start()
    {
        StartCoroutine(Spawning());
        wait = GetComponent<WaitForNextWave>();
       
    }

    internal IEnumerator Spawning()
    {
        WaveStructure wave = waveData[GlobalData.WaveIndex];
        
            yield return new WaitForSeconds(Random.Range(0.5f, 0.8f));
            for (int i = 0; i < wave.waveDataList.Count; i++)
            {
                yield return new WaitForSeconds(wave.waveDataList[i].delay);
                StartCoroutine(SpawnWaveData(wave.waveDataList[i]));
            }
          
        StartCoroutine(wait.WaitForWave());


    }
    private IEnumerator SpawnWaveData(WaveData data)
    {
        for (int i = 0; i < data.amount; i++)
        {
            int chosenIndex = Random.Range(0, 2);
            Transform spawnedEnemy = Instantiate(enemies[(int)data.id].transform, spawnpos[chosenIndex].position, Quaternion.identity);
            spawnedEnemy.GetComponent<Move>().Lane = GameObject.Find("Waypoint Manager").GetComponent<LanesScript>().lanes[chosenIndex];
            soundManager.enemies.Add(spawnedEnemy.gameObject);
            yield return new WaitForSeconds(data.spacing);
        }
    }

    public static ScriptableObject CreateInstance(WaveData waveData)
    {
        return Instantiate(waveData);
    }
  
    void Update()
    {
        
    }
}
