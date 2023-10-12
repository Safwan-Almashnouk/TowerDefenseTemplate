using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    }
}
