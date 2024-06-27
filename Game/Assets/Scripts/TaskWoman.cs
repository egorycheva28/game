using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWoman : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog1;

    // Use this for initialization
    void Start()
    {
        if (Dialog1 == null)
        {
            Debug.LogError("Dialog1 is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EndDialog)
        {
            EndCurrentDialog();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            StartDialog();
        }
    }

    private void StartDialog()
    {
        Time.timeScale = 0;
        Dialog1.SetActive(true);
    }

    private void EndCurrentDialog()
    {
        Time.timeScale = 1;
        Dialog1.SetActive(false);
        EndDialog = false; // Reset EndDialog to avoid repeated calls
    }
}
