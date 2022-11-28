using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBasic : ClassTurret
{
    public Collider2D[] inRange;
    LayerMask enemyLayer;

    private void Start()
    {
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
        
        {
           
        }
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
        if (inRange.Length != 0 && attackTimer == 0)
        {
            Vector2 target = inRange[0].transform.position;
            float angle = Mathf.Atan2(target.x - transform.position.x, target.y - transform.position.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);
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
