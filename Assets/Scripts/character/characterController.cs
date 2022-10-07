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
    //Variable que definira si se juega en dispositivo movil o pc
    [HideInInspector]
    public ControllerType controller;
    int cantidad_click; 
    bool puedo_dar_click; 

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        cantidad_click = 0;
        puedo_dar_click = true;
       
        
    }
    // Update is called once per frame
    void Update()
    {
        if(controller==ControllerType.PC){
            attackSword();
        }
    }
    void FixedUpdate() {
            move();
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
    }
   
    

//***************************COMBO DE ATAQUE*****************************************************
     void Iniciar_combo(){
        if (puedo_dar_click){
            cantidad_click++;
        }

        if (cantidad_click == 1){
            anim.SetInteger("attackSword", 1);
        }
    }

    public void Verificar_combo(){

        puedo_dar_click = false;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 1") && cantidad_click == 1){
            anim.SetInteger("attackSword", 0);
            puedo_dar_click = true;
            cantidad_click = 0;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 1") && cantidad_click >= 2){       
            anim.SetInteger("attackSword", 2);
            puedo_dar_click = true;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 2") && cantidad_click == 2){       
            anim.SetInteger("attackSword", 0);
            puedo_dar_click = true;
            cantidad_click = 0;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 2") && cantidad_click >= 3){       
            anim.SetInteger("attackSword", 3);
            puedo_dar_click = true;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 3")){      
            anim.SetInteger("attackSword", 0);
            puedo_dar_click = true;
            cantidad_click = 0;
        }
    }

    public void attackSword(){
        if (Input.GetKeyDown(KeyCode.Backspace)) { Iniciar_combo(); }
    }
    public void attackSwordMobile(){
        Iniciar_combo();
    }

    public void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("arma")){
            print("prueba daño");
        }
        
    }



}
