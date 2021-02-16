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
    public Quaternion swingRotateNormal;
    public bool canAttack = true;

    public GameObject player;
    public GameObject shield;
    public int shieldSlow;
    public float blockTime;
    public Vector3 blockMove;
    public Vector3 blockRotate;
    public bool toBlock;

    private void Start()
    {
        swingMoveNormal = sword.transform.localPosition;
        swingRotateNormal = sword.transform.localRotation;
        //StartCoroutine(SwordAttack());
    }

    // Update is called once per frame
    void Update()
    {
        if  (Input.GetButtonDown("Fire2"))
        {
            player.GetComponent<PlayerMovement>().moveSpeed -= shieldSlow;
            player.GetComponent<PlayerMovement>().sprintSpeed = 1;
            toBlock = true;
            blockTime = 0.3f - blockTime;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            player.GetComponent<PlayerMovement>().moveSpeed += shieldSlow;
            player.GetComponent<PlayerMovement>().sprintSpeed = 1.5f;
            toBlock = false;
            blockTime = 0.3f - blockTime;
        }
        if (Input.GetButton("Fire2"))
        {
            //insert shield code
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            if (canAttack == true)
            {
                if (blockTime <= 0)
                {
                    if (Physics.Raycast(transform.position, transform.forward, out hit, 2.5f))
                    {
                        hit.collider.gameObject.GetComponent<MobHitPoints>().DoDamage(swordDamage);
                    }
                    StartCoroutine(SwordAttack());
                }
            }
        }
        //if (swingTime >= 0)
        //{
        //   if (swingTime >= 0.8f * swingSpeed)
        //    {
        //        sword.transform.Translate(4 * swingMove * Time.deltaTime);
        //        sword.transform.Rotate(4 * swingRotate * Time.deltaTime);
        //    }
        //    else
        //    {
        //        sword.transform.Translate(- swingMove * Time.deltaTime);
        //        sword.transform.Rotate(- swingRotate * Time.deltaTime);
        //    }
        //    swingTime -= Time.deltaTime;
        //}
        //else
        //{
        //    sword.transform.localPosition = swingMoveNormal;
        //    //sword.transform.localRotation = swingRotateNormal;
        //}
        if (blockTime >= 0)
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

    public IEnumerator SwordAttack()
    {
        canAttack = false;
        for (float f = 0; f < swingSpeed; f += Time.deltaTime)
        {
            if (f < 0.2 * swingSpeed)
            {
                sword.transform.Rotate(4 * swingRotate * Time.deltaTime);
            }
            else
            {
                sword.transform.Rotate(-swingRotate * Time.deltaTime);
            }
            yield return null;
        }
        canAttack = true;
    }
}
