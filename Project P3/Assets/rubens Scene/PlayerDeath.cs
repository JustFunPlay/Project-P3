using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject.tag == "DeathTrap")
        {
            print("hello");
        }
    }
}
