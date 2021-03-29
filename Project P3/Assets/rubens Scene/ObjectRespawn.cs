using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRespawn : MonoBehaviour
{
    public Vector3 teleportLocationAUTO;
    public bool allowTeleport;
    public GameObject[] objectsToTeleport;

    void Start()
    {
        teleportLocationAUTO = transform.position;
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject.tag == "DeathTrap")
        {
            if (allowTeleport == true)
            {
                transform.position = teleportLocationAUTO;
            }
        }
    }
}
