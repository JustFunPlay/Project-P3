using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyAIDinand
{
    public GameObject weaponObject;
    public int minAttack;
    public int maxAttack;
    public float critChance;
    public override IEnumerator Attack()
    {
        RaycastHit hit;
        for (float f = 0; f < timeBetweenAttacks * 0.4f; f+= Time.deltaTime)
        {
            weaponObject.transform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
            yield return null;
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                int damage = Random.Range(minAttack, maxAttack);
                float critRoll = Random.Range(0f, 1f);
                if (critRoll <= critChance)
                {
                    damage += damage;
                    print("critical hit");
                }
                hit.collider.gameObject.GetComponent<PlayerHitPoints>().DoDamage(damage);
            }
        }
        for (float f = 0; f < timeBetweenAttacks * 0.4f; f += Time.deltaTime)
        {
            weaponObject.transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
            yield return null;
        }
    }
}
