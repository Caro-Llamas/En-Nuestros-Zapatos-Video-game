using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public double time;
    public double currentTime;

    public GameObject exitButton;

    // Use this for initialization
    void Start()
    {

        time = GetComponent<VideoPlayer>().clip.length;
    }


    // Update is called once per frame
    void Update()
    {
        currentTime = GetComponent<VideoPlayer>().time;
        if (currentTime >= time-3)
        {
            exitButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager.sharedInstance.ReturnToMainMenu();
            }
        }
    }
}
