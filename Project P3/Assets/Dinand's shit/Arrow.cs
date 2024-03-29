﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 shoot;
    public int damage;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(shoot);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<PlayerHitPoints>().DoDamage(damage);
            Vector3 p = transform.position;
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(200, p, 4, 50);
                print("knockback");
            }
        }
        Destroy(gameObject);
    }
}
