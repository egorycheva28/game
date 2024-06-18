using UnityEngine;
using UnityEngine.UI;

public class TextSwitcher : MonoBehaviour
{
    public Text[] texts;  
    public Button nextButton;
    public Button prevButton;
    private int currentIndex = 0;  // индекс текущего текста

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
}
