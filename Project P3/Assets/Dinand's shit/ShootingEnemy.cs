using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyAIDinand
{
    public GameObject arrow;
    public GameObject shootPosition;
    public override void Attack()
    {
        Instantiate(arrow, shootPosition.transform.position, transform.rotation);
    }
}
