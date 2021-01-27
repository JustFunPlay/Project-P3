using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHitPoints : MonoBehaviour
{
    public int hp;
    public int collisionDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<PlayerHitPoints>().DoDamage(collisionDamage);
        }
    }
    public void DoDamage(int damageToDo)
    {
        hp -= damageToDo;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
