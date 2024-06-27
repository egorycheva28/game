using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextSwitcher : MonoBehaviour
{
    public Text[] texts;
    public Button nextButton;
    public Button prevButton;
    private int currentIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(ShowNextText);
        prevButton.onClick.AddListener(ShowPreviousText);

        UpdateTextVisibility();
    }

    void ShowNextText()
    {
        if (currentIndex < texts.Length - 1)
        {
            currentIndex++;
            UpdateTextVisibility();
        }
        else
        {
            LoadNextScene();
        }
    }

    void ShowPreviousText()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateTextVisibility();
        }
    }

    void UpdateTextVisibility()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(i == currentIndex);
        }
    }

    void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Достигнут конец списка сцен в билде!");
        }
    }
}
