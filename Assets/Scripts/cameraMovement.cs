using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject reference;
    private Vector3 distance;
    //panel tactil
    public FixedTouchField touchField;
    // Start is called before the first frame update
    void Start()
    {
        //vector que va del jugador hasta la camara
        distance=transform.position-player.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        distance=Quaternion.AngleAxis(touchField.TouchDist.x*4,Vector3.up)*distance;
        transform.position=player.transform.position+distance;
        transform.LookAt(player.transform.position);

        //referencia para que los controles no cambien
        Vector3 copyRotation=new Vector3(0,transform.eulerAngles.y,0);
        reference.transform.eulerAngles=copyRotation;
    }
}
