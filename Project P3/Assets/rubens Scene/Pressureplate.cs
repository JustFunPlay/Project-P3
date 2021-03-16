﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressureplate : MonoBehaviour
{
    public GameObject platform;
    public bool pressureCheck;

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
            pressureCheck = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if(col.collider.gameObject.tag == "weight")
        {
            platform.SetActive(false);
            pressureCheck = false;
        }
        else if(col.collider.gameObject.name == "Player")
        {
            if (pressureCheck == false)
            {
                platform.SetActive(false);
            }
        }
    }
}
