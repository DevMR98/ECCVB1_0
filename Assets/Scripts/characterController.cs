using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float movementVelocity=5.0f;
    public float rotationVelocity=200.0f;
    private Animator anim;
    //tomando porpiedades del joystick touch
    public FixedJoystick joystick;
    float x,y;

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        x=joystick.input.x;
        y=joystick.input.y;

        //control de la rotacion
        transform.Rotate(0,x*Time.deltaTime*rotationVelocity,0);
        //control de movimiento del personaje
        transform.Translate(0,0,y*Time.deltaTime*movementVelocity);

        //asignando el movimeinto al animator
        anim.SetFloat("velX",x);
        anim.SetFloat("velY",y);
        
    }
}
