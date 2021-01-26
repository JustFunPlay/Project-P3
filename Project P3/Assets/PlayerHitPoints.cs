using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitPoints : MonoBehaviour
{
    public int hp = 30;
    public int damageTaken;
    public float invisFrames;
    public float invisTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invisFrames <= 0)
        {
            if (damageTaken > 0)
            {
                hp -= damageTaken;
                invisFrames = invisTime;
            }
        }
        damageTaken = 0;
        if (invisFrames > 0)
        {
            invisFrames -= Time.deltaTime;
        }

        if (hp <= 0)
        {
            print("game over");
        }
    }
}
