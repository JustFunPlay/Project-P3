using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorePressure : MonoBehaviour
{
    public GameObject platform;
    public bool enableCheck;
    public bool pressureCheck;
    public bool enableCheck2;
    public bool pressureCheck2;
    public GameObject pressurePlateObject;

    // Start is called before the first frame update
    void Start()
    {
        platform.SetActive(false);
    }
    void Update()
    {
        if(pressurePlateObject.GetComponent<MorePressure>().pressureCheck == true)
        {
            print("hello");
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.name == "Player")
        {
            platform.SetActive(true);
        }
        else if (col.collider.gameObject.tag == "weight")
        {
            platform.SetActive(true);
            if(enableCheck2 == true)
            {
                pressureCheck2 = true;
            }
            else if(enableCheck == true)
            {
                pressureCheck = true;
            }
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.collider.gameObject.tag == "weight")
        {
            platform.SetActive(false);
            pressureCheck2 = false;
        }
        else if (col.collider.gameObject.name == "Player")
        {
            if (pressureCheck == false)
            {
                if (pressureCheck2 == false)
                {
                    if (pressurePlateObject.GetComponent<MorePressure>().pressureCheck == false)
                    {
                        if (pressurePlateObject.GetComponent<MorePressure>().pressureCheck2 == false)
                        {
                            platform.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
