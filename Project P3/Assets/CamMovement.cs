using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float v;
    public int turnSpeed;
    public Vector3 turn;
    public float min;
    public float max;
    public Vector3 e;

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Mouse Y");
        turn.x = v * turnSpeed * -1;
        GetComponent<Transform>().Rotate(turn * Time.deltaTime);

        e = transform.eulerAngles;
        if (e.x > 180)
        {
            e.x -= 360;
        }
        e.x = Mathf.Clamp(e.x, -90, 90);
        transform.eulerAngles = e;
    }
}
