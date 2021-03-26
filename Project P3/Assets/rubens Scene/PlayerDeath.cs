using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public int damageTrap;
    public Vector3 teleportLocation;
    public GameObject teleportWho;
    //teleport who kan ook als de speler worden gebruikt.
    public void Start()
    {
        damageTrap = 10;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "DeathTrap")
        {
            teleportWho.GetComponent<PlayerHitPoints>().hp -= damageTrap;
            GotPlayerDamage();
            transform.position = teleportLocation;
        }
    }
    public void GotPlayerDamage()
    {
            if(teleportWho.GetComponent<PlayerHitPoints>().hp <= -0.1)
            {
                Destroy(teleportWho);
            }
    } 
}
