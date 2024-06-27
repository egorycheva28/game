using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanDialog : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    private bool isText1 = true;
    public TaskWoman TaskWomanScript;

    // Use this for initialization 
    void Start()
    {
        // Ensure Text1 and Text2 are initialized properly 
        if (Text1 == null || Text2 == null)
        {
            Debug.LogError("Text1 or Text2 is not assigned.");
        }

        // Ensure TaskWomanScript is initialized 
        if (TaskWomanScript == null)
        {
            TaskWomanScript = FindObjectOfType<TaskWoman>();
            if (TaskWomanScript == null)
            {
                Debug.LogError("TaskWoman script is not found in the scene.");
            }
        }
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isText1 = !isText1;

            if (isText1)
            {
                TaskWomanScript.EndDialog = true;
            }
        }

        Text1.SetActive(isText1);
        Text2.SetActive(!isText1);
    }
}
