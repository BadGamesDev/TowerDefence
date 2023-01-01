using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : ClassEnemy
{
    private void Awake()
    {
        hitPointMax = 25;
        hitPoint = 25;
        speed = 1;
        size = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "BulletBasic(Clone)")
        {
            hitPoint -= collision.collider.GetComponent<BulletBasic>().damage;
        }
        if (hitPoint <= 0) //works for now since only direct hits can reduce hp, can be moved to update if need be
        {
            Destroy(gameObject);
        }
    }
}
