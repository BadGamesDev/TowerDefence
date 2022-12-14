using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour
{
    private Rigidbody2D bulletBody;
    
    public Transform target;
    
    public float damage;
    public float speed;

    private void Start()
    {
        bulletBody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rotateBullet();
        chaseTarget();
    }
    
    void rotateBullet()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bulletBody.rotation = angle;
    }
    
    void chaseTarget()
    {
        bulletBody.position = Vector3.MoveTowards(transform.position, target.position, speed);
        
        if(target == null) //find a better looking solution when polishing the game
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
