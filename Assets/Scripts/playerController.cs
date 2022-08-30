using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public bool enableMobibleInputs = false;
    public FixedJoystick joystick;
    float currentVelocity;
    float currentSpeed;
    public float smothRotationTime = 0.25f;
    float moveSpeed = 5f;
    float speedVelocity;
    public bool global;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 input = Vector2.zero;

        if (enableMobibleInputs)
        {
            input = new Vector2(joystick.input.x, joystick.input.y);
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        }


        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smothRotationTime);
        }

        float tragetSpeed = moveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, tragetSpeed, ref speedVelocity, 0.1f);
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

    }


}
