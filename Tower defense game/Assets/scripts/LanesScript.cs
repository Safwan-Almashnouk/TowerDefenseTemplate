using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesScript : MonoBehaviour
{
    public GameObject[] lanes;
    void Start()
    {
        lanes = new GameObject[transform.childCount];
        
        for (int i = 0; i < transform.childCount; i++)
        {
            lanes[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
