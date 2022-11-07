using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apples : MonoBehaviour
{
    public characterController life;
    

    public void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("Player")){
            life.currentLife+=20f;
            Destroy(gameObject);
        }
    }
}
