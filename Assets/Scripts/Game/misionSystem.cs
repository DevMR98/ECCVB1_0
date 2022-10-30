using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class misionSystem : MonoBehaviour
{
    public int numEnemys;
    public Text textEnemy;
    public GameObject nextMision;
    // Start is called before the first frame update

    void Start(){
       textEnemy.text="Derrota a todos los enemigos restan 3/"+numEnemys;
    }
    void update(){
        if(numEnemys==3){
            textEnemy.color=Color.yellow;
            nextMision.SetActive(true);
        }
    }
   

}
