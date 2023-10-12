using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyScript : MonoBehaviour
{
    private float timer = 1;
    private float delay = 1;
    private float increase;
    public TMP_Text currency;


    private void Start()
    {
        increase = Random.RandomRange(40,101);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= delay)
        {
            timer= 0;
            GlobalData.playerCurr += increase;
        }

        currency.text = GlobalData.playerCurr.ToString();
    }
}
