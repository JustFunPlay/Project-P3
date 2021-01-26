using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAndShield : MonoBehaviour
{
    public RaycastHit hit;
    public int swordDamage;
    public float swingTime;
    public float swingSpeed;

    public float shieldSlow;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            //insert shield code
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            if (swingTime <= 0)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 2.5f))
                {
                    hit.collider.gameObject.GetComponent<MobHitPoints>().hp -= swordDamage;
                }
                swingTime = swingSpeed;
            }
        }
        if (swingTime > 0)
        {
            swingTime -= Time.deltaTime;
        }
    }
}
