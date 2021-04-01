using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCubeCollection : MonoBehaviour
{
    public bool[] keyCubesCollected;
    public Text text;
    public Text objectiveText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KeyCube")
        {
            for (int i = 0; i < keyCubesCollected.Length; i++)
            {
                if (keyCubesCollected[i] == false)
                {
                    keyCubesCollected[i] = true;
                    Destroy(other.gameObject);
                    int a = i + 1;
                    text.text = a.ToString();
                    if (a >= keyCubesCollected.Length)
                    {
                        objectiveText.text = "Open the door to fight the boss";
                        text.text = "";
                    }
                    return;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "CubeDoor")
        {
            for (int i = 0; i < keyCubesCollected.Length; i++)
            {
                if (keyCubesCollected[i] == false)
                {
                    return;
                }
            }
            objectiveText.text = "Defeat the Boss";
            Destroy(collision.collider.gameObject);
        }
    }
}
