using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausaMenu : MonoBehaviour
{
    public GameObject btnPausa,MenuP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pause(){
        //para detener el tiempo en el juego
        Time.timeScale=0f;
        btnPausa.SetActive(false);
        MenuP.SetActive(true);
    }

    public void resume(){
        Time.timeScale=1f;
        btnPausa.SetActive(true);
        MenuP.SetActive(false);
    }

    public void mainMenu(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale=1f;
    }

    public void close(){
        Application.Quit();
        Debug.Log("Se cerro la aplicación");
    }
}
