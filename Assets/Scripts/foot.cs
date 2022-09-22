using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot : MonoBehaviour
{
    public characterController cController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        cController.canJump=true;

    }

    private void OnTriggerExit(Collider other) {
        cController.canJump=false;
    }
}
