using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVisual : MonoBehaviour
{
    public GameObject nextLevel;
    private SpriteRenderer sd;
    private SpriteRenderer currentSd;
    private Sprite fakeSprite;
    private TowerScript towerS;
    private RaycastHit2D upgradeTarget;


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

        Debug.Log(hit.collider.gameObject.name);

        if (hit.collider.gameObject.CompareTag("Player"))
        {
           
            currentSd = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            sd.sprite = currentSd.sprite;
            upgradeTarget = hit;
            Debug.Log(hit.collider.gameObject.name);
        }
       
    }

    public void Upgrade()
    {
        if (upgradeTarget == null)
        {
            return;
        }
      
        nextLevel = upgradeTarget.collider.gameObject.GetComponent<TowerScript>().nextLevel;
        Instantiate(nextLevel, upgradeTarget.collider.gameObject.transform.position, upgradeTarget.collider.gameObject.transform.rotation);
        Destroy(upgradeTarget.collider.gameObject);
        
        
    }





}
