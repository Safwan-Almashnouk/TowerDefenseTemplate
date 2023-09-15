using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float projjectileSpeed;
    public TowerScript tower;
    internal Transform enemyLoc;
    public Move HP;
    public float damage;
    

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
            target.GetComponent<Move>().currhealth -= damage;
            Debug.Log(HP.currhealth);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLoc == null) 
        {
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.localPosition, enemyLoc.position, projjectileSpeed * Time.deltaTime) ;
    }
}
