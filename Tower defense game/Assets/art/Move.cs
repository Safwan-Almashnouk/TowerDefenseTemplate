using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float damage;
    public float Maxhealth;
    public float currhealth;
    public waypointManager waypoint;
    int currrentIndex;
    public GameObject Lane;
    internal float prog;
    
    void Start()
    {

        waypoint = Lane.GetComponent<waypointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = waypoint.waypoints[currrentIndex].position - transform.position;
 ;
        if (delta.magnitude <= 0.1) 
        {
            currrentIndex++;
        }
        delta.Normalize();
        
        transform.position += delta * Time.deltaTime * speed;

        if(currhealth <= 0)
        {
            Debug.Log("dead");
            Destroy(gameObject);

        }
        prog += Time.deltaTime;
    }


}
