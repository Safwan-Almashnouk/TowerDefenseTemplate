using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public float atkSpeed;
    public float damage;
    public GameObject bullets;
    // public GameObject Level2;
    [SerializeField] private bool shouldShoot = true;
    private List<GameObject> targets;
    private Transform towerPos;

    void Start()
    {
        targets = GetComponentInChildren<RangeScript>().enemiesInRange;
        Vector2 towerPos = new Vector2(transform.position.x, transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count <= 0)
        {
            return;
        }

        if (shouldShoot == true)
        {
            GameObject bullet = Instantiate(bullets, transform.position, transform.rotation);
            GameObject[] sortToFirst = targets.OrderBy(e => e.GetComponent<Move>().prog).ToArray();
            bullet.GetComponent<BulletScript>().enemyLoc = sortToFirst[0].transform;
            bullet.GetComponent<BulletScript>().damage = damage;
            shouldShoot = false;
            StartCoroutine(WaitForDelay());
        }
    }
    IEnumerator WaitForDelay()
    {
       
       
          yield return new WaitForSeconds(atkSpeed);
        shouldShoot = true;
    }

}
