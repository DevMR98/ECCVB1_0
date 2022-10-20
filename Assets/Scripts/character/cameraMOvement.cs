using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMOvement : MonoBehaviour
{
    private float speedH=1f;
    private float speedV=1;
    public FixedTouchField touchField;
    float yaw,pitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw+=speedH*touchField.TouchDist.x;
        pitch+=speedV*touchField.TouchDist.y;
        transform.eulerAngles=new Vector3(pitch,yaw,0.0f);
        
    }
}
