using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionTrigger : MonoBehaviour
{
    public GameObject transitionButton;

    void Start()
    {
        if (transitionButton != null)
        {
            transitionButton.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (transitionButton != null)
            {
                transitionButton.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (transitionButton != null)
            {
                transitionButton.SetActive(false);
            }
        }
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene("NextSceneName");
    }
}