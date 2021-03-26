using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasNumber : MonoBehaviour
{
    public int hpNumber;
    public GameObject playerHPCount;
    public Text textHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       hpNumber = playerHPCount.GetComponent<PlayerHitPoints>().hp;

        textHP.text = hpNumber.ToString();
    }
}
