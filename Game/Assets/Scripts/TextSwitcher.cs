using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextSwitcher : MonoBehaviour
{
    public Text[] texts;
    public Button nextButton;
    public Button prevButton;
    public Image image;
    private int currentIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(ShowNextText);
        prevButton.onClick.AddListener(ShowPreviousText);

        image.gameObject.SetActive(false);

        UpdateUI();
    }

    void ShowNextText()
    {
        if (currentIndex < texts.Length - 1)
        {
            currentIndex++;
            UpdateUI();
        }
        else
        {
            ShowImage();
        }
    }

    void ShowPreviousText()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(i == currentIndex);
        }

        prevButton.gameObject.SetActive(currentIndex > 0);
        nextButton.gameObject.SetActive(currentIndex < texts.Length);
    }

    void ShowImage()
    {
        foreach (var text in texts)
        {
            text.gameObject.SetActive(false);
        }

        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);

        image.gameObject.SetActive(true);
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
