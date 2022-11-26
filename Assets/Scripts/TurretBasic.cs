using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBasic : ClassTurret
{
    public Collider[] intersecting;

    private void Start()
    {
        price = 100;
        attack = 10;
        attackRange = 5;
        attackSpeed = 1;
        projectileChoice = 0;
    }

    private void Update()
    {
        intersecting = Physics.OverlapSphere(gameObject.transform.position, attackRange);
        if (intersecting.Length != 0)
        {
            //Instantiate(projectiles[projectileChoice], transform.position, transform.rotation);
            Debug.Log("shoot");
        }
    }
}
