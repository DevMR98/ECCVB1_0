using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    private float Sensibilidad=5f;
    float x, y;
    public FixedJoystick joy;
    public float Speed = 2;

    void FixedUpdate()
    {
        x += TouchPad.instance.Horizontal;
        y -= TouchPad.instance.Vertical;

        this.transform.rotation = Quaternion.Euler (y, x, Sensibilidad);

        this.transform.Translate (joy.Horizontal * Time.deltaTime * Speed, 0f, joy.Vertical * Time.deltaTime * Speed);
    }
}
