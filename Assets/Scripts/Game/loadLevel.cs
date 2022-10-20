using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//permite crear las escenas de una a otra
using UnityEngine.UI;
public class loadLevel : MonoBehaviour
{
    public GameObject pantallaCarga;
    public Slider slider;

    public void loadL(int numeroE){
        StartCoroutine(cargarAsync(numeroE));

    }

    //corrutina funcion que pausa su ejecucion para dar control a unity y continuar en el siguiente fram
    IEnumerator cargarAsync(int numeroE){

        //permite cargar la siguiente escena d euna manera que no quite recursos a la scena actual
        AsyncOperation operacion=SceneManager.LoadSceneAsync(numeroE);
        pantallaCarga.SetActive(true);
        Time.timeScale=1f;

        while(!operacion.isDone){
            float progreso=Mathf.Clamp01(operacion.progress/.9f);//fija un valor de 0 a 1
            Debug.Log(progreso);
            slider.value=progreso;
            //esperara un frame hasta temrinar con el chequeo
            yield return null;
        }

    }
}
