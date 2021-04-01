using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasNumber : MonoBehaviour
{
    public int hpNumber;
    public GameObject playerHPCount;
    public Text textHP;
    public GameObject[] deadText;

    void Update()
    {
       hpNumber = playerHPCount.GetComponent<PlayerHitPoints>().hp;

        textHP.text = hpNumber.ToString();
    }
    public void GameEndButton()
    {
        SceneManager.LoadScene(0);
    }
    public void Defeat()
    {
        deadText[0].SetActive(true);
        deadText[1].SetActive(true);
    }
    public void Victory()
    {
        deadText[0].SetActive(true);
        deadText[2].SetActive(true);
    }
}
