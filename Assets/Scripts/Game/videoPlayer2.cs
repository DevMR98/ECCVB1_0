using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoPlayer2 : MonoBehaviour
{
    public VideoPlayer video;
    public loadLevel load;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        video.GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached+=CheckOver;
    }

    void CheckOver(VideoPlayer vp){
        //gameObject.SetActive(false);
        panel.SetActive(true);
        load.loadL(5);
    }
}
