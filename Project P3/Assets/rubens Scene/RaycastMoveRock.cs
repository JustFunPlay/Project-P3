using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastMoveRock : MonoBehaviour
{
    public RaycastHit hit;
    public Vector3 extramove;
    public GameObject testObject;
    public Rigidbody Rigidbody;
    public bool pickingUpObject;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Physics.Raycast(transform.position, transform.forward, out hit, 1.5f);

            if (hit.collider.gameObject.tag == "weight")
            {
                {
                    hit.rigidbody.gameObject.GetComponent<PlayerMovement>().moveSpeed = 5;
                    pickingUpObject = true;
                }
            } 
        }
        if (Input.GetButtonDown("Fire2"))
        {
            hit.rigidbody.gameObject.GetComponent<PlayerMovement>().moveSpeed = 0;
            pickingUpObject = false;
        }
    }
}

      

// dit was de eerste oplossing die ik gebruikte om de kubus te laten bewegen.
            //if (hit.collider.gameObject.tag == "weight")
           
            //hit.rigidbody.gameObject.transform.position += extramove;
   
