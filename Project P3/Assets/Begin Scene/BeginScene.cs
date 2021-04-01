using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginScene : MonoBehaviour
{
    public GameObject[] buttons;

    public void DisableFirstMenu()
    {
        buttons[0].SetActive(false);
        buttons[4].SetActive(false);
        buttons[7].SetActive(false);
    }
    public void DisablePlayMenu()
    {
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        buttons[6].SetActive(false);
    }
    public void DisableCreditsMenu()
    {
        buttons[5].SetActive(false);
        buttons[6].SetActive(false);
    }
    public void DisableSettingsenu()
    {
        buttons[6].SetActive(false);
    }
    public void EnableFirstMenu()
    {
        buttons[0].SetActive(true);
        buttons[4].SetActive(true);
        buttons[7].SetActive(true);
        buttons[6].SetActive(false);
    }
    public void EnablePlayMenu()
    {
        buttons[1].SetActive(true);
        buttons[2].SetActive(true);
        buttons[3].SetActive(true);
        buttons[6].SetActive(true);
    }
    public void EnableCreditsMenu()
    {
        buttons[5].SetActive(true);
        buttons[6].SetActive(true);
    }
    public void EnableSettingsMenu()
    {
        buttons[6].SetActive(true);
    }

    //Dit is het gedeelte waar als op een knop drukt dat je een een andere Scene gaat.
    public void StartLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene(3);
    }

}
