using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class UpgradeVisual : MonoBehaviour
{
    public GameObject nextLevel;
    private SpriteRenderer sd;
    private SpriteRenderer currentSd;
    private Sprite fakeSprite;
    private TowerScript towerS;
    private RaycastHit2D upgradeTarget;
    public TMP_Text statsTextField;
    private int canUpgrade;

    private void Start()
    {
        GameObject spritePlaceHolder = GameObject.FindGameObjectWithTag("TowerExample");
        sd = spritePlaceHolder.GetComponent<SpriteRenderer>();
        fakeSprite = sd.sprite;


    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
       
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 1000, LayerMask.GetMask("Towers"));

        if (hit.collider == null)
        {
            return;
        }

  

        if (hit.collider.gameObject.CompareTag("Player"))
        {
            TowerScript stats = hit.collider.GetComponent<TowerScript>();
            currentSd = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            sd.sprite = currentSd.sprite;
            upgradeTarget = hit;
            statsTextField.text = $"Attack : {stats.damage}\t AtkSpeed:{stats.atkSpeed}\t UpgradeCost:{stats.UpgradeCost}";


        }
       
    }

    public void Upgrade()
    {
        if (upgradeTarget == null)
        {
            return;
        }
       
        canUpgrade = upgradeTarget.collider.gameObject.GetComponent<TowerScript>().UpgradeCost;
        if (canUpgrade <= GlobalData.playerCurr)
        {
            nextLevel = upgradeTarget.collider.gameObject.GetComponent<TowerScript>().nextLevel;
            Instantiate(nextLevel, upgradeTarget.collider.gameObject.transform.position, upgradeTarget.collider.gameObject.transform.rotation);
            Destroy(upgradeTarget.collider.gameObject);
            sd.sprite = nextLevel.gameObject.GetComponent<SpriteRenderer>().sprite;
            GlobalData.playerCurr -= canUpgrade;
        }
        else
        {
            return;
        }


    }


}
