using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectRespawn : MonoBehaviour
{
    public Vector3 teleportLocationAUTO;
    public bool allowTeleport;

    // voor alleen 1 pressure plate
    public bool levelComplete;
    public GameObject canvas;

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
        // dit is alleen voor 1 pressure plate
        if(levelComplete == true)
        {
            canvas.GetComponent<CanvasNumber>().Victory();
        }
    }
}
