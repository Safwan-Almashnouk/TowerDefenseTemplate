using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public TMP_Text health;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        health.text = GlobalData.Health.ToString();

        if (GlobalData.Health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
