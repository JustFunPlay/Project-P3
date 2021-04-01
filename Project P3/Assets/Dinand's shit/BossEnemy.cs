using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossEnemy : MeleeEnemy
{
    public Text text;
    public GameObject playerObj;
    public override void OnDeath()
    {
        text.text = "Congratulations, you have beaten the boss";
        playerObj.GetComponent<PlayerHitPoints>().ReturnToScene();
    }
}
