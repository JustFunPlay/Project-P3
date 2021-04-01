using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginScene : MonoBehaviour
{
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableFirstMenu()
    {
        buttons[0].SetActive(false); 
    }
    public void EnableSecondMenu()
    {
        buttons[1].SetActive(true);
        buttons[2].SetActive(true);
        buttons[3].SetActive(true);
    }
    public void StartLevel1()
    {
        Application.LoadLevel("Ruben's Scene");
    }
    public void StartLevel2()
    {
        Application.LoadLevel("Nitish's Scene");
    }
    public void StartLevel3()
    {
        Application.LoadLevel("Dinand's Scene");
    }

}
