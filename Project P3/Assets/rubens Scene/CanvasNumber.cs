using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasNumber : MonoBehaviour
{
    public int hpNumber;
    public GameObject playerHPCount;
    public Text textHP;

    void Update()
    {
       hpNumber = playerHPCount.GetComponent<PlayerHitPoints>().hp;

        textHP.text = hpNumber.ToString();
    }
}
