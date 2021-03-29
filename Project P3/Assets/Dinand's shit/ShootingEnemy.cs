using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyAIDinand
{
    public GameObject arrow;
    public GameObject shootPosition;
    public override IEnumerator Attack()
    {
        //shootPosition. colorchange
        for (float f = 0; f < 0.5f; f+=Time.deltaTime)
        {
            yield return null;
        }
        Instantiate(arrow, shootPosition.transform.position, transform.rotation);
        //shootPosition. colorreturn
    }
}
