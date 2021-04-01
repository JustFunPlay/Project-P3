using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCube : MonoBehaviour
{
    public Vector3 turning;
    void Update()
    {
        transform.Rotate(turning * Time.deltaTime);
    }
}
