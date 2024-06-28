using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionTrigger : MonoBehaviour
{
    public GameObject transitionPanel;
    public int numberScene;

    private bool playerInTrigger = false;

    void Start()
    {
        if (transitionPanel != null)
        {
            transitionPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            GoToNextScene();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            if (transitionPanel != null)
            {
                transitionPanel.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            if (transitionPanel != null)
            {
                transitionPanel.SetActive(false);
            }
        }
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(numberScene);
    }
}