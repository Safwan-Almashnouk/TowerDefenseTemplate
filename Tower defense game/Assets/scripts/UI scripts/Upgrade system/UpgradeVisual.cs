using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class UpgradeVisual : MonoBehaviour
{
    public GameObject nextLevel;
    private SpriteRenderer sd;
    private SpriteRenderer currentSd;
    private Sprite fakeSprite;
    private RaycastHit2D upgradeTarget;
    public GameObject selectedTower;
    public TMP_Text statsTextField;
    private TowerScript selectedTowerScript;

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
            selectedTower = hit.collider.gameObject;

            statsTextField.text = $"Attack : {stats.damage}\t AtkSpeed:{stats.atkSpeed}\t UpgradeCost:{stats.UpgradeCost}";
        }
       
    }

    public void Upgrade()
    {
        if (upgradeTarget == null)
        {
            return;
        }
        selectedTowerScript = selectedTower.GetComponent<TowerScript>();
        if (selectedTowerScript.UpgradeCost <= GlobalData.playerCurr)
        {
            
            GameObject newSelected = Instantiate(selectedTowerScript.nextLevel, selectedTower.transform.position, selectedTower.transform.rotation);
            Destroy(selectedTower);
            selectedTower = newSelected;
            sd.sprite = newSelected.GetComponent<SpriteRenderer>().sprite;
            GlobalData.playerCurr -= selectedTowerScript.UpgradeCost;

            TowerScript newStats = newSelected.GetComponent<TowerScript>();
            statsTextField.text = $"Attack : {newStats.damage}\t AtkSpeed:{newStats.atkSpeed}\t UpgradeCost:{newStats.UpgradeCost}";
        }
        else
        {
            return;
        }
    }


}
