using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeScript : MonoBehaviour
{
    public List<GameObject> enemiesInRange= new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInRange.Add(collision.gameObject);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collision.gameObject);
        }
    }

}
