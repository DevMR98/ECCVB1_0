using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionMenu : MonoBehaviour
{
    public Slider sliderV,sliderB;
    public float sliderVV,sliderVB;
    public Image mute,pBrillo;

    // Start is called before the first frame update
    void Start()
    {
        //Volumen
        sliderV.value=PlayerPrefs.GetFloat("sliderVolumen",0.5f);
        AudioListener.volume=sliderV.value;
        isMute();

        //Brillo
        sliderB.value=PlayerPrefs.GetFloat("Brillo",0.5f);
        pBrillo.color=new Color(pBrillo.color.r,pBrillo.color.g,pBrillo.color.g,sliderB.value);
        
    }

    public void changeSliderV(float value){
        sliderVV=value;
        PlayerPrefs.SetFloat("sliderVolumen",sliderVV);
        AudioListener.volume=sliderV.value;
        isMute();

    }

    public void changeSliderB(float value){
        sliderVV=value;
        PlayerPrefs.GetFloat("Brillo",sliderVV);
        pBrillo.color=new Color(pBrillo.color.r,pBrillo.color.g,pBrillo.color.g,sliderB.value);
    }

    public void isMute(){
        if(sliderVV==0){
            mute.enabled=true;
        }else{
            mute.enabled=false;
        }

    }

}
