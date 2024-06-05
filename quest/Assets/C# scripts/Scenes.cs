using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Scenes : MonoBehaviour // https://www.youtube.com/watch?v=9Ctjf0rtpRQ&list=TLPQMDUwNjIwMjQgFwc6JxkS-A&index=1
{
    public void  ChangeScenes(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
