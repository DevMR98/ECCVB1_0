using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public Textos text;
    void Start(){
        FindObjectOfType<controlDialog>().activateCartel(text);
    }

}
