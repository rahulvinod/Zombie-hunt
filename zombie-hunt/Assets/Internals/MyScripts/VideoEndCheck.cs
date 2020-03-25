using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndCheck : MonoBehaviour
{

    public VideoPlayer vid;
    //public GameObject cont;
    public int Scene_load;

    // Start is called before the first frame update
    void Start()
    {
        vid.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
 
        
    }

    void EndReached(VideoPlayer vid)
    {
        SceneManager.LoadScene(Scene_load);
    }
}
