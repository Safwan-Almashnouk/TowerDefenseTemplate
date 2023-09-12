using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public Transform[] spawnpos; 
    public int selector;
    public GameObject[] enemies; 
    public bool Attackstate = true;
    
    void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while (Attackstate == true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 0.8f));
            int chosenIndex = Random.Range(0, 2);
            Transform spawnedEnemy = Instantiate(enemies[0].transform, spawnpos[chosenIndex].position, Quaternion.identity);
            spawnedEnemy.GetComponent<Move>().Lane = GameObject.Find("Waypoint Manager").GetComponent<LanesScript>().lanes[chosenIndex];
        }
        

    }
  
    void Update()
    {
        
    }
}
