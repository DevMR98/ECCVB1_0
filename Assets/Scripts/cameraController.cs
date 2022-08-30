using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
//agregando comentario enm el script cameraControll.
    public float Yaxis;
    public float Xaxis;
    public float rotationSensitivity = 0.5f;
    public bool enableMobileInput = false;
    public FixedTouchField touchField;
    public Transform target;

    void Update()
    {

        if (enableMobileInput)
        {
            Yaxis += touchField.TouchDist.x * rotationSensitivity;
            Xaxis -= touchField.TouchDist.y * rotationSensitivity;

        }
        else
        {
            Yaxis += Input.GetAxis("Mouse X") * rotationSensitivity;
            Xaxis -= Input.GetAxis("Mouse Y") * rotationSensitivity;

        }

        Vector3 targetRotation = new Vector3(Xaxis, Yaxis);
        transform.eulerAngles = targetRotation;
        transform.position = target.position - transform.forward * 2f;
    }



}
