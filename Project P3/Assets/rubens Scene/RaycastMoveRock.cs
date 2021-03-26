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
    public bool true1;
    public bool true2;
    // Start is called before the first frame update
    void Update()
    {
        Physics.Raycast(transform.position, transform.forward, out hit, 100f)



            if (Input.GetButtonDown("Fire1")) 
            {

                if (hit.collider.gameObject.tag == "weight")
                {
                     if (true1 == true)
                     {
                         print("working");
                         true1 = false;
                         true2 = true;
                         hit.rigidbody.gameObject.GetComponent<PlayerMovement>().moveSpeed = 5;
                     }
            }



        
    }  
}

      


            //if (hit.collider.gameObject.tag == "weight")
           
                //hit.rigidbody.gameObject.transform.position += extramove;
   
