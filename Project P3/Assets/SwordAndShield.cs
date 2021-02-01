using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAndShield : MonoBehaviour
{
    public RaycastHit hit;
    public GameObject sword;
    public int swordDamage;
    public float swingTime;
    public float swingSpeed;
    public Vector3 swingMove;
    public Vector3 swingRotate;
    public Vector3 swingMoveNormal;
    public Vector3 swingRotateNormal;

    public GameObject player;
    public GameObject shield;
    public int shieldSlow;
    public float blockTime;
    public Vector3 blockMove;
    public Vector3 blockRotate;
    public bool toBlock;

    // Update is called once per frame
    void Update()
    {
        if  (Input.GetButtonDown("Fire2"))
        {
            player.GetComponent<PlayerMovement>().moveSpeed -= shieldSlow;
            player.GetComponent<PlayerMovement>().sprintSpeed = 1;
            toBlock = true;
            blockTime = 0.3f;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            player.GetComponent<PlayerMovement>().moveSpeed += shieldSlow;
            player.GetComponent<PlayerMovement>().sprintSpeed = 1.5f;
            toBlock = false;
            blockTime = 0.3f;
        }
        if (Input.GetButton("Fire2"))
        {
            //insert shield code
        }
        else if (Input.GetButton("Fire1"))
        {
            if (swingTime <= 0)
            {
                if (blockTime <= 0)
                {
                    if (Physics.Raycast(transform.position, transform.forward, out hit, 2.5f))
                    {
                        hit.collider.gameObject.GetComponent<MobHitPoints>().DoDamage(swordDamage);
                    }
                    swingTime = swingSpeed;
                }
            }
        }
        if (swingTime > 0)
        {
            if (swingTime > 0.8f * swingSpeed)
            {
                sword.transform.Translate(4 * swingMove * Time.deltaTime);
                sword.transform.Rotate(4 * swingRotate * Time.deltaTime);
            }
            else
            {
                sword.transform.Translate(- swingMove * Time.deltaTime);
                sword.transform.Rotate(- swingRotate * Time.deltaTime);
            }
            swingTime -= Time.deltaTime;
        }
        else
        {
            sword.transform.localPosition = swingMoveNormal;
            //sword.transform.localRotation = swingRotateNormal;
        }
        if (blockTime > 0)
        {
            if (toBlock == true)
            {
                shield.transform.Translate(blockMove * Time.deltaTime);
                shield.transform.Rotate(blockRotate * Time.deltaTime);
            }
            if (toBlock == false)
            {
                shield.transform.Translate(-blockMove * Time.deltaTime);
                shield.transform.Rotate(-blockRotate * Time.deltaTime);
            }
            blockTime -= Time.deltaTime;
        }
    }
}
