using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : ClassEnemy
{
    private void Awake()
    {
        hitPointMax = 50;
        hitPoint = 50;
        speed = 1;
        size = 1;
    }  
}
