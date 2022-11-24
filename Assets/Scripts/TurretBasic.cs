using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBasic : ClassTurret
{
    CircleCollider2D rangeCollider;

    private void Awake()
    {
        price = 100;
        attack = 10;
        attackRange = 5;
        attackSpeed = 1;
        projectileChoice = 0;
        rangeCollider = gameObject.GetComponent<CircleCollider2D>();
        rangeCollider.radius = 5;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Instantiate(projectiles[projectileChoice], transform.position, transform.rotation);
        Debug.Log("shoot");
    }

}
