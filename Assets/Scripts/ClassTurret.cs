using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTurret : MonoBehaviour
{
    //public float price;
    public float attack;
    public float attackSpeed;
    public float attackRange;

    //public int targetPriority; //priority choices to add: first-closest-last-strongest 
    public int projectileChoice;
    
    public GameObject basicBullet;
    public GameObject[] projectiles;

    private void Start()
    {
        projectiles = new GameObject[1]; // horrible way of doing things, fix it!
        projectiles[0] = basicBullet;
    }
    public void Shoot()
    {
        Instantiate(projectiles[projectileChoice],transform.position,transform.rotation);
        Debug.Log("shoot");
    }
}
