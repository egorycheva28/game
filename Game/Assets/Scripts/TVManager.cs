using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class TVManager : MonoBehaviour
{
    public VideoPlayer video; public bool enter;
    bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isPlaying = !isPlaying;
            }
        }
        if (isPlaying)
        {
            video.Play();
        }
        else
        {
            video.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        enter = true;
    }
    private void OnTriggerExit(Collider other)
    {
        enter = false;
    }
}

