using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //comprobar si el dispositivo es movil o pc
    //public bool enableMobibleInputs = false;
    //tomando porpiedades del joystick touch
    public FixedJoystick joystick;
    private Rigidbody rb;
    private float speed=5f;
    //limitar velocidad
    //private float maxSpeed=10f;
    public GameObject reference;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        movement();

        
    }

    public void movement(){
            //Capturando direccion de movimiento
            float horizontalMovement=joystick.input.x;
            float verticalMovement=joystick.input.y;

        /* Se movia pero sin parar asi que a csm
        //Limitando la velocidad maxima
        if(rb.velocity.magnitude>maxSpeed){
            rb.velocity=rb.velocity.normalized*maxSpeed;
        }
        //agregando fuerza para el movimiento del player
        rb.AddForce(verticalMovement*reference.transform.forward*speed);
        rb.AddForce(horizontalMovement*reference.transform.right*speed);
        */

        if(horizontalMovement!=0.0f || verticalMovement!=0.0f){
            Vector3 dir=reference.transform.forward*verticalMovement+reference.transform.right*horizontalMovement;
            rb.MovePosition(transform.position+dir*speed*Time.deltaTime);
        }
    }
}
