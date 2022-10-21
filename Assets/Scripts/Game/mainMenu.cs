using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public GameObject option;
    public bool menuOP = false;

    public void close()
    {
        Application.Quit();
        Debug.Log("Se cerro la aplicación");
    }

    public void optionMenu()
    {
        option.SetActive(true);
    }

    public void regresar()
    {
        option.SetActive(false);
    }

}
