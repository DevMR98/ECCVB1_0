using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatePanelActivities : MonoBehaviour
{
    public GameObject panelActivities;
    //public GameObject pause;
    

    public void openPanel(){
        panelActivities.SetActive(true);
        //pause.SetActive(false);
    }

    public void closePanel(){
        panelActivities.SetActive(false);
    }
}
