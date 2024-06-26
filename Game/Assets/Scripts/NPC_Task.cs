using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Добавьте эту строку для использования TMP элементов
using UnityEngine.UI; // Добавьте эту строку для использования UI элементов

public class NPC_Task : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog1;
    public TMP_InputField AnswerInputField; // Поле для ввода ответа
    public Button SubmitButton; // Кнопка для подтверждения ответа
    public string correctAnswer; // Правильный ответ на загадку

    // Use this for initialization
    void Start()
    {
        if (Dialog1 == null)
        {
            Debug.LogError("Dialog1 is not assigned.");
        }

        if (AnswerInputField == null || SubmitButton == null)
        {
            Debug.LogError("InputField or SubmitButton is not assigned.");
        }

        // Добавление слушателя для кнопки
        SubmitButton.onClick.AddListener(CheckAnswer);
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

    private void CheckAnswer()
    {
        if (AnswerInputField.text.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Правильный ответ!");
            // Действие при правильном ответе
            EndCurrentDialog();
            AnswerInputField.gameObject.SetActive(false);
            SubmitButton.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Неправильный ответ. Попробуйте еще раз.");
            // Действие при неправильном ответе
        }
    }
}
