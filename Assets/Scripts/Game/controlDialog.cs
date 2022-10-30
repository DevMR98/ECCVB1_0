using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlDialog : MonoBehaviour
{
    private Animator anim;
    private Queue<string> queueDialog;
    Textos text;
    [SerializeField] TextMeshProUGUI textScreen;
    

    public void activateCartel(Textos textObj){
        text=textObj;
    }

    public void activateText(){
       queueDialog.Clear();
       foreach (string saveText in text.arrayTexts)
       {
        queueDialog.Enqueue(saveText);
       }
       nextSentence();
    }

    public void nextSentence(){
        if(queueDialog.Count==0){
            closeCartel();
            return;
        }

        string actualSentence=queueDialog.Dequeue();
        textScreen.text=actualSentence;

    }

    public void closeCartel(){
        anim.SetBool("cartel",false);
    }
}
