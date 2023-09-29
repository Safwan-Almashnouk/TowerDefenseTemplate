using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelection : MonoBehaviour
{
    public GameObject SelectedTower;
    [SerializeField] private bool isDragging;
    [SerializeField] private bool placeable;
    private Vector2 offset, ogPos;


    void Start()
    {
        ogPos = transform.position;
    }
    void Update()
    {
        if(! isDragging) return;

        Vector2 mousePos = GetMousePos();
        transform.position = mousePos - offset;
    }

    private void OnMouseDown()
    {
       
        Instantiate(SelectedTower, transform.position, Quaternion.identity);
        isDragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        transform.position = ogPos;
        isDragging = false;
       // Destroy(SelectedTower);
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
