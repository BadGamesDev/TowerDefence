using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBasic : ClassTurret
{
    public Collider2D[] intersecting;
    LayerMask enemyLayer;

    private void Awake()
    {
        enemyLayer = LayerMask.GetMask("EnemyUnit");
        //price = 100;
        attack = 10;
        attackRange = 5;
        attackSpeed = 1;
        projectileChoice = 0;
    }

    private void Update()
    {
        intersecting = Physics2D.OverlapCircleAll(gameObject.transform.position, attackRange, enemyLayer);
        if (intersecting.Length != 0)
        {
            Shoot();
        }
    }
}
