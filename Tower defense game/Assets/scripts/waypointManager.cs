using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointManager : MonoBehaviour
{
    public Transform[] waypoints;
    void Start()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            waypoints[i] = gameObject.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
