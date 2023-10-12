using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip WalkingNoise;
    private float Delay;
    private AudioSource audio;
    private bool isPlaying;
    [SerializeField] internal List<GameObject> enemies = new List<GameObject>(); 


    private void Start()
    {
        Delay = WalkingNoise.length;
        audio= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count >= 1 && !isPlaying)
        {
            audio.PlayOneShot(WalkingNoise, Delay);
            isPlaying = true;
            StartCoroutine(Loop());
        }
        else
        {
            return;
        }
        
    }

    IEnumerator Loop()
    {
       yield return new WaitForSeconds(Delay);
       isPlaying= false;
       
    }
}
