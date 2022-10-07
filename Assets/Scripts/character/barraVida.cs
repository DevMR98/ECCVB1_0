using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraVida : MonoBehaviour
{
    
    public Image barraDeVida;
    public int vidaMax;
    public float vidaActual;

    
    // Start is called before the first frame update
    void Start()
    {
        vidaActual=vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        revisarVida();

        if(vidaActual<=0){
            gameObject.SetActive(false);
        }
        
    }

    public void revisarVida(){
        barraDeVida.fillAmount=vidaActual/vidaMax;

    }
}
