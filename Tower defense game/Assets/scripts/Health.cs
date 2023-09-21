using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float Maxhealth;
    public float currhealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currhealth <= 0)
        {
            Debug.Log("dead");
            Destroy(gameObject);

        }
    }
}
