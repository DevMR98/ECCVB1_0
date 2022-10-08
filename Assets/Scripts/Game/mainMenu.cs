using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public void close(){
        Application.Quit();
        Debug.Log("Se cerro la aplicación");
    }
}
