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
    //Comprobacion salto
    public bool  canJump;
    public Rigidbody rb;
    public float jumpForce=8f;
    //Variable que definira si se juega en dispositivo movil o pc
    [HideInInspector]
    public ControllerType controller;

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        canJump=false;
       
        
    }

    // Update is called once per frame
    void Update()
    {

        
        //salto
        if(controller==ControllerType.PC){
            jump();
        }else{
            jumpMobile();
        }
        
        
        
    }

    void FixedUpdate() {
        move();
    }

    public void jump(){
        if(canJump){
            if(Input.GetButtonDown("Jump")){
            anim.SetBool("jump",true);
            rb.AddForce(new Vector3(0,jumpForce,0),ForceMode.Impulse);
            }
            anim.SetBool("isOnFloor",true);    
        }else{
            isFallen();
        }
    }

    public void jumpMobile(){
         if(canJump){
            anim.SetBool("jump",true);
            rb.AddForce(new Vector3(0,jumpForce,0),ForceMode.Impulse);
            anim.SetBool("isOnFloor",true);    
        }else{
            isFallen();
        }

    }

    public void isFallen(){
        anim.SetBool("isOnFloor",false);
        anim.SetBool("jump",false);
    }

    public void move(){

        if(controller==ControllerType.PC){
            x=Input.GetAxis("Horizontal");
            y=Input.GetAxis("Vertical");

        //control de la rotacion
        transform.Rotate(0,x*Time.deltaTime*rotationVelocity,0);
        //control de movimiento del personaje
        transform.Translate(0,0,y*Time.deltaTime*movementVelocity); 

        //asignando el movimeinto al animator
        anim.SetFloat("velX",x);
        anim.SetFloat("velY",y);

        }else{
            x=joystick.input.x;
            y=joystick.input.y;

            //asignando el movimeinto al animator
            anim.SetFloat("velX",x);
            anim.SetFloat("velY",y);

            //control de la rotacion
            transform.Rotate(0,x*Time.deltaTime*rotationVelocity,0);
            //control de movimiento del personaje
            transform.Translate(0,0,y*Time.deltaTime*movementVelocity);
        }

        
       

    /*
        //control de la rotacion
        transform.Rotate(0,x*Time.deltaTime*rotationVelocity,0);
        //control de movimiento del personaje
        transform.Translate(0,0,y*Time.deltaTime*movementVelocity); 

        


        //asignando el movimeinto al animator
        anim.SetFloat("velX",x);
        anim.SetFloat("velY",y);
*/
    }

    

    



   


}
