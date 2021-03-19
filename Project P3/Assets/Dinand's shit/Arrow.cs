using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 shoot;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Rigidbody>().AddForce(shoot);
    }

    private void Update()
    {
        transform.Translate(shoot * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.gameObject.GetComponent<PlayerHitPoints>().DoDamage(damage);
        Vector3 p = transform.position;
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddExplosionForce(100, p, 4, 50);
            print("knockback");
        }
        Destroy(gameObject);
    }
}
