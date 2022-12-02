using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBasic : ClassTurret
{
    private Rigidbody2D turretBody;
    
    public Collider2D[] inRange;
    LayerMask enemyLayer;
    
    private void Start()
    {
        turretBody = gameObject.GetComponent<Rigidbody2D>();

        enemyLayer = LayerMask.GetMask("EnemyUnit");
        attackDamage = 10;
        attackTimerMax = 5;
        attackTimer = 0;
        attackRange = 5;

        projectileSpeed = 2.5f;
    }

    private void Update()
    {
        inRange = Physics2D.OverlapCircleAll(gameObject.transform.position, attackRange, enemyLayer);
    }

    private void FixedUpdate()
    {
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
            turretBody.rotation = angle;
        }
    }

    void fireTurret()
    {
        if (inRange.Length != 0 && attackTimer == 0)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().AddForce(newProjectile.transform.right * projectileSpeed, ForceMode2D.Impulse);
            Debug.Log("shoot");
            attackTimer = attackTimerMax;
        } 
    }
}
