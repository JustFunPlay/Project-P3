using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitPoints : MonoBehaviour
{
    public int hp = 30;
    public float invisFrames;
    public float invisTime;
    public Text hpText;

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
            hpText.text = hp.ToString();
        }
        if (hp <= 0)
        {
            print("Game Over");
        }
    }
}
