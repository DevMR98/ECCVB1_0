using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ControllerType{
        PC,MOBILE
    }
    
public class gameMnager : MonoBehaviour
{
    

    public ControllerType controller;
    public characterController player;
    public GameObject mobileController;
    // Start is called before the first frame update
    void Start()
    {
        controllerSetUp();
    }

    void Update() {
        controllerSetUp();
    }

    public void controllerSetUp(){

        
        if(controller==ControllerType.PC){
            mobileController.SetActive(false);
        }
        if(controller==ControllerType.MOBILE){
            mobileController.SetActive(true);
        }
        player.controller=controller;
    }
}
