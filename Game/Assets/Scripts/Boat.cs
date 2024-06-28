using UnityEngine;
using UnityEngine.SceneManagement;

public class Boat : MonoBehaviour
{
    [SerializeField]
    private GameObject keyObject;
    [SerializeField]
    private GameObject truePanel;

    [SerializeField]
    private GameObject falsePanel;

    public int finalScene;

    private bool playerInTrigger = false;

    private bool complete = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            UpdatePanels();
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
        if (playerInTrigger && complete && Input.GetKeyDown(KeyCode.U))
        {
            if (keyObject.activeInHierarchy)
            {
                SceneManager.LoadScene(finalScene);
            }
        }
    }

    private void UpdatePanels()
    {
        if (keyObject.activeInHierarchy)
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
