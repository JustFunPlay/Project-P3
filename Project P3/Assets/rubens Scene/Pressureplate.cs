using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressureplate : MonoBehaviour
{
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject.name == "Player")
        {
            platform.SetActive(true);
        }
        else if(col.collider.gameObject.tag == "weight")
        {
            platform.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if(col.collider.gameObject.tag == "weight")
        {
            platform.SetActive(false);
        }
        else if(col.collider.gameObject.name == "Player")
        {
            if (col.collider.gameObject.tag == "weight" == true)
            {
                platform.SetActive(false);
            }
        }
    }
}
