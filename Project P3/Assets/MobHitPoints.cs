using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHitPoints : MonoBehaviour
{
    public int hp;
    public int collisionDamage;
    public bool isLarge;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<PlayerHitPoints>().DoDamage(collisionDamage);
            Vector3 p = transform.position;
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(100, p, 4, 50);
                print("knockabk");
            }
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
