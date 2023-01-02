using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBasic : ClassTurret
{
    private Rigidbody2D turretHead;
    
    public Collider2D[] inRange;
    
    LayerMask enemyLayer;

    private void Start()
    {
        turretHead = gameObject.GetComponentInChildren<Rigidbody2D>();

        enemyLayer = LayerMask.GetMask("EnemyUnit");
        attackDamage = 10;
        attackTimerMax = 2.5f;
        attackTimer = 0;
        attackRange = 5;

        projectileSpeed = 0.2f;
    }

    private void FixedUpdate()
    {
        inRange = Physics2D.OverlapCircleAll(gameObject.transform.position, attackRange, enemyLayer);

        if (attackTimer > 0)
        {
            attackTimer -= Time.fixedDeltaTime;
        }
        else
        { 
            attackTimer = 0; 
        }
        
        rotateTurret();
        fireTurret();
    }
    
    void rotateTurret()
    {
        if (inRange.Length != 0)
        {
            Vector3 direction = inRange[0].transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            turretHead.rotation = angle;
        }
    }

    void fireTurret()
    {
        if (inRange.Length != 0 && attackTimer == 0)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);           
            newProjectile.GetComponent<BulletBasic>().target = inRange[0].transform;
            newProjectile.GetComponent<BulletBasic>().damage = attackDamage;
            newProjectile.GetComponent<BulletBasic>().speed = projectileSpeed;
            attackTimer = attackTimerMax;
        } 
    }
}
