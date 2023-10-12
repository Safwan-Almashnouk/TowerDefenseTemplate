using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public float damage;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            GlobalData.Health -= damage;
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
            
        }
    }
    void Update()
    {
        
    }
}
