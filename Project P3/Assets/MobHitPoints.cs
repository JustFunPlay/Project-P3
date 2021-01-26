using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHitPoints : MonoBehaviour
{
    public int hp;
    public int collisionDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<PlayerHitPoints>().damageTaken = collisionDamage;
        }
    }
}
