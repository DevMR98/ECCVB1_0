using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogKingSancho : MonoBehaviour
{
    public GameObject symbolMission;
    public characterController player;
    public GameObject panelNpc1;
    public GameObject panelNpc2;
    public GameObject mission2;
    public GameObject npcSancho;
    //public GameObject panelNpcMission;
    public TextMeshProUGUI textMission;
    public bool playerNear;
    public bool acceptMission;
    public AudioSource dialogRS;
    public Text mission1;



    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<characterController>();
        symbolMission.SetActive(true);
        panelNpc1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
            playerNear=true;
            if(acceptMission==false){
                panelNpc1.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.tag=="Player"){
            playerNear=false;
            panelNpc1.SetActive(false);
            panelNpc2.SetActive(false);
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
        dialogRS.Play();
        mission1.color=Color.red;
        mission2.SetActive(true);
        npcSancho.SetActive(true);
    }
}
