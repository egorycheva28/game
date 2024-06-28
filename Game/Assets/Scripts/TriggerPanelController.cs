/*using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPanelController : MonoBehaviour
{


    public GameObject truePanel;
    public GameObject falsePanel;

    public int finalScene;

    private bool playerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            if (ForCheck.allFlowersInPlace==true)
            {
                truePanel.SetActive(true);
                falsePanel.SetActive(false);
            }
            else
            {
                truePanel.SetActive(false);
                falsePanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            truePanel.SetActive(false);
            falsePanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInTrigger && ForCheck.allFlowersInPlace==true && Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene(finalScene);
        }
    }
}*/
