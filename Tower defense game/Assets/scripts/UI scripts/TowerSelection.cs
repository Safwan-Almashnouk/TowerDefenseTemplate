using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelection : MonoBehaviour
{
    public GameObject SelectedTower;
    [SerializeField] private bool isDragging;
    [SerializeField] private bool placeable;
 
    private Vector2 offset;
    public float price;


    void Start()
    {
        offset= transform.position;
    }
    void Update()
    {
        if(! isDragging) return;

        Vector2 mousePos = GetMousePos();
        transform.position = mousePos - offset;
    }

    private void OnMouseDown()
    {
       if(price <= GlobalData.playerCurr)
        {
            Instantiate(SelectedTower, transform.position, Quaternion.identity);
            isDragging = true;
          

        }
        
    }

    private void OnMouseUp()
    {
        transform.position = offset;
        isDragging = false;

        if (price <= GlobalData.playerCurr)
        { 
            GlobalData.playerCurr -= price;
        }
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
