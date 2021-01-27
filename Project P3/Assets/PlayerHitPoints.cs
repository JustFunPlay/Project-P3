using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitPoints : MonoBehaviour
{
    public int hp = 30;
    public int damageTaken;
    public float invisFrames;
    public float invisTime;

    // Update is called once per frame
    void Update()
    {
        if (invisFrames > 0)
        {
            invisFrames -= Time.deltaTime;
        }
    }

    public void DoDamage(int damageTodo)
    {
        if (invisFrames <= 0)
        {
            hp -= damageTodo;
            invisFrames = invisTime;
        }
        if (hp <= 0)
        {
            print("Game Over");
        }
    }
}
