using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LockToMouse : MonoBehaviour
{
    public GameObject tower;
    private Vector2 ogPos;
    [SerializeField] private bool validPlacement;
    public float returnPrice;

    

    void Start()
    {
        ogPos = transform.position;
       
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Grass")
        {
            
            validPlacement = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Grass")
        {
           
            StartCoroutine(WaitTillEndOfFrame());
        }
    }



    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        hasBeenPlaced();
        

    }
    private IEnumerator WaitTillEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        validPlacement = false;
    }

    private void hasBeenPlaced()
    {
        if (Input.GetMouseButtonUp(0) && validPlacement == true)
        {
            Instantiate(tower, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        else if (Input.GetMouseButtonUp(0) && !validPlacement)
        {
            Destroy(gameObject);
            GlobalData.playerCurr += returnPrice;
            
        }
    }
}

