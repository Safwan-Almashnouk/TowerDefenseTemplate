using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVisual : MonoBehaviour
{
    public GameObject nextLevel;
    private SpriteRenderer sd;
    private SpriteRenderer currentSd;
    private Sprite playerSprite;


    private void Start()
    {
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject SpriteExample = GameObject.FindGameObjectWithTag("TowerExample");
        sd = SpriteExample.GetComponent<SpriteRenderer>();  
        currentSd = GetComponent<SpriteRenderer>();
        playerSprite = currentSd.sprite;
    }

    private void OnMouseDown()
    {
        sd.sprite = playerSprite;
    }
   


}
