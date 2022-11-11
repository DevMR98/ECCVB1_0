using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lsitGameObjects : MonoBehaviour
{
    public GameObject[] enemiList;
    public int enemiTotal;
    public GameObject final;
    public enemyControllerAlfonso enemy;
    // Start is called before the first frame update
    void Start()
    {
         
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiList = new GameObject[transform.childCount];
        
        //LLenar el arreglo con los modelos
        for (int i = 1; i < transform.childCount; i++)
            enemiList[i] = transform.GetChild(i).gameObject;
        
        enemiTotal=enemiList.Length;
        enemy.textFinalMissionL2.SetText("Derrota a los 5 rebeldes. Restan "+enemiTotal);

        if(enemiTotal==0){
            final.SetActive(true);
        }
        
    }
}
