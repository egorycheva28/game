using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Для использования TMP элементов
using UnityEngine.UI; // Для использования UI элементов

public class ManTask : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog1;
    public TMP_InputField AnswerInputField; // Поле для ввода ответа
    public Button SubmitButton; // Кнопка для подтверждения ответа
    public Button ThinkButton; // Кнопка для продолжения без отображения книги
    public GameObject Book; // Объект книги
    public string correctAnswer; // Правильный ответ на загадку
    private bool dialogCompleted = false; // Флаг для отслеживания завершенного диалога
    private bool puzzleSolved = false; // Флаг для отслеживания правильного ответа на загадку
    // Use this for initialization
    void Start()
    {
        if (Dialog1 == null)
        {
            Debug.LogError("Dialog1 is not assigned.");
        }
        if (AnswerInputField == null || SubmitButton == null || ThinkButton == null || Book == null)
        {
            Debug.LogError("One or more UI elements are not assigned.");
        }
        // Добавление слушателей для кнопок
        SubmitButton.onClick.AddListener(CheckAnswer);
        ThinkButton.onClick.AddListener(Think);
        // Initially hide the book
        Book.SetActive(false);
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
        if (col.CompareTag("Player") && !dialogCompleted)
        {
            StartDialog();
        }
    }
    private void StartDialog()
    {
        Time.timeScale = 0;
        Dialog1.SetActive(true);
        AnswerInputField.gameObject.SetActive(!puzzleSolved);
        SubmitButton.gameObject.SetActive(!puzzleSolved);
        ThinkButton.gameObject.SetActive(!puzzleSolved);
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
            Debug.Log("Правильный ответ!");            // Показать книгу
            Book.SetActive(true);            // Закрыть диалог
            EndCurrentDialog();            // Установить флаг завершенного диалога
            dialogCompleted = true;
            puzzleSolved = true;
        }
        else
        {
            Debug.Log("Неправильный ответ. Попробуйте еще раз.");
            // Действие при неправильном ответе        }
        }
    }
    private void Think()
    {
        Debug.Log("Подумать ещё.");
        EndCurrentDialog();
    }

}
