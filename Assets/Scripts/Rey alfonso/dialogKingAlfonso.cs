using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class dialogKingAlfonso : MonoBehaviour
{
    public GameObject symbolMission;
    public characterController player;
    public GameObject panelNpc1;
    public GameObject panelNpc2;
    public GameObject mission4;
    public GameObject collFinalMission;
    //public GameObject panelNpcMission;
    public TextMeshProUGUI textMission3;
    public bool playerNear;
    public bool acceptMission;
    //public AudioSource dialogRA;
    public Transform playerPosition;
    public NavMeshAgent kingAlfonso;
    public bool whitin;
    public Animator anim;
    

   



    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<characterController>();
        anim=GetComponent<Animator>();
        symbolMission.SetActive(true);
        panelNpc1.SetActive(false);
        kingAlfonso=GetComponent<UnityEngine.AI.NavMeshAgent>();
        kingAlfonso.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(kingAlfonso.enabled==true){
            if(!whitin){
            kingAlfonso.destination=playerPosition.position;
            anim.SetBool("run",true);
            
        }else{
            kingAlfonso.destination=transform.position;
            anim.SetBool("run",false);
        }
        }
        
    }

    public void acceptMissionButton(){
        if(!acceptMission){
            Vector3 playerPositiion=new Vector3(transform.position.x, player.gameObject.transform.position.y, transform.position.z);
            player.gameObject.transform.LookAt(playerPositiion);

            player.anim.SetFloat("velX",0);
            player.anim.SetFloat("velY",0);
            player.enabled=false;
            panelNpc1.SetActive(false);
            panelNpc2.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            //kingAlfonso.enabled=false;
            playerNear=true;
            if(acceptMission==false){
                panelNpc1.SetActive(true);
            }
            whitin=true;
        }
    }

    private void OnTriggerExit(Collider other){
        //kingAlfonso.enabled=false;
        if(other.tag=="Player"){
            playerNear=false;
            panelNpc1.SetActive(false);
            panelNpc2.SetActive(false);
            whitin=false;
        }
    }


    public void buttonNo(){
        player.enabled=true;
        panelNpc1.SetActive(true);
        panelNpc2.SetActive(false);
    }

    public void buttonYes(){
        player.enabled=true;
        acceptMission=true;
        playerNear=false;
        symbolMission.SetActive(false);
        panelNpc1.SetActive(false);
        panelNpc2.SetActive(false);
        //dialogRA.Play();
        textMission3.color=Color.red;
        //textMission2.IsActive(true);
        mission4.SetActive(true);
        kingAlfonso.enabled=true;
        collFinalMission.SetActive(true);
    }
}
