using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAndShield : MonoBehaviour
{
    public RaycastHit hit;
    public int swordDamage;
    public float swingTime;
    public float swingSpeed;

    public GameObject player;
    public int shieldSlow;

    // Update is called once per frame
    void Update()
    {
        if  (Input.GetButtonDown("Fire2"))
        {
            player.GetComponent<PlayerMovement>().moveSpeed -= shieldSlow;
            player.GetComponent<PlayerMovement>().sprintSpeed = 1;
            //schild gaat naar voren
        }
        if (Input.GetButtonUp("Fire2"))
        {
            player.GetComponent<PlayerMovement>().moveSpeed += shieldSlow;
            player.GetComponent<PlayerMovement>().sprintSpeed = 1.5f;
            //schild gaat terug naar normaal
        }
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
                    hit.collider.gameObject.GetComponent<MobHitPoints>().DoDamage(swordDamage);
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
