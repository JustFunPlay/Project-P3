using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed;
    public int jumpHeight;
    public Vector3 move;
    public bool canJump;
    public float x;
    public float z;

    public float cam;
    public int turnSpeed;
    public Vector3 turning;

    public bool shieldDecreaseSpeed;
    public int[] shieldSpeedNumber;

    // Update is called once per frame
    void Update()
    {
        if(shieldDecreaseSpeed == true)
        {
            moveSpeed = shieldSpeedNumber[0];
        }
        if(shieldDecreaseSpeed == false)
        {
            moveSpeed = shieldSpeedNumber[1];
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (canJump == true)
            {
                move.y = jumpHeight;
                canJump = false;
            }
        }

        cam = Input.GetAxis("Mouse X");
        turning.y = cam * turnSpeed;
        GetComponent<Transform>().Rotate(turning * Time.deltaTime);

        x = Input.GetAxis("Vertical");
        z = Input.GetAxis("Horizontal");
        move.x = z * moveSpeed;
        if (x > 0)
        {
            if (Input.GetButton("Sprint"))
            {
                move.z = x * moveSpeed * 1.5f;
            }
            else
            {
                move.z = x  * moveSpeed;
            }
        }
        else
        {
            move.z = x * moveSpeed;
        }
        GetComponent<Transform>().Translate(move * Time.deltaTime);

        if (move.y > 0.1f)
        {
            move.y *= 0.95f;
        }
        if (move.y < 1)
        {
            if (move.y != 0)
            {
                move.y = 0;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            canJump = true;
        }
    }
}
