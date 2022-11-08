using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterController : MonoBehaviour
{
    public Image lifeBar;
    public float maxLife=100f;
    public float currentLife=100f;
    //public GameObject gameOver;
    //public bool Death=false;
    public float movementVelocity=8.5f;
    public float rotationVelocity=400.0f;
    public Animator anim;
    //tomando porpiedades del joystick touch
    public FixedJoystick joystick;
    float x,y;
    //Variable que definira si se juega en dispositivo movil o pc
    [HideInInspector]
    public ControllerType controller;
    //para el combo de ataque
    int clickAmount; 
    bool canGiveClick; 
    public GameObject panelFinishMission;
    //public GameObject apple;
    //public AudioSource audioFinal;
    public GameObject finalMissionL2;
    public TextMeshProUGUI textMission3;
    public GameObject gameOver;
    public GameObject rebeldes;
  

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        clickAmount = 0;
        canGiveClick = true;
        
        
    }
    // Update is called once per frame
    void Update()
    {
    
        if(controller==ControllerType.PC || controller==ControllerType.MOBILE){
            attackSword();
        }
        
        lifeBar.fillAmount=(currentLife/maxLife);
        deathPlayer();
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

        }else if(controller==ControllerType.MOBILE ){
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
//*************************************ATAQUE*******************************************




    

//***************************COMBO DE ATAQUE*****************************************************
     void initComboo(){
        if (canGiveClick){
            clickAmount++;
        }

        if (clickAmount == 1){
            anim.SetInteger("attackSword", 1);
        }
    }

    public void checkCombo(){

        canGiveClick = false;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && clickAmount == 1){
            anim.SetInteger("attackSword", 0);
            canGiveClick = true;
            clickAmount = 0;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && clickAmount >= 2){       
            anim.SetInteger("attackSword", 2);
            canGiveClick = true;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && clickAmount == 2){       
            anim.SetInteger("attackSword", 0);
            canGiveClick = true;
            clickAmount = 0;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && clickAmount >= 3){       
            anim.SetInteger("attackSword", 3);
            canGiveClick = true;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3")){      
            anim.SetInteger("attackSword", 0);
            canGiveClick = true;
            clickAmount = 0;
        }
    }

    public void attackSword(){
        if (Input.GetKeyDown(KeyCode.Backspace)) { initComboo(); }
    }
    public void attackSwordMobile(){
        initComboo();
    }


    public void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("arma")){
            print("prueba daño"); 
            currentLife-=2f; 
        }
        else if(coll.CompareTag("finishLevel")){
            panelFinishMission.SetActive(true);
            Time.timeScale=0f;
            //audiofinal.Play();
        }else if(coll.CompareTag("Toledo")){
            finalMissionL2.SetActive(true);
            textMission3.color=Color.red;
            rebeldes.SetActive(true);
        }
    }

    public void deathPlayer(){
        if(lifeBar.fillAmount==0){
            gameOver.SetActive(true);
        }
    }

    




}
