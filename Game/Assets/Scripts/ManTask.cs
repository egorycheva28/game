using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // ��� ������������� TMP ���������
using UnityEngine.UI; // ��� ������������� UI ���������

public class ManTask : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog1;
    public TMP_InputField AnswerInputField; // ���� ��� ����� ������
    public Button SubmitButton; // ������ ��� ������������� ������
    public Button ThinkButton; // ������ ��� ����������� ��� ����������� �����
    public GameObject Book; // ������ �����
    public string correctAnswer; // ���������� ����� �� �������
    private bool dialogCompleted = false; // ���� ��� ������������ ������������ �������
    private bool puzzleSolved = false; // ���� ��� ������������ ����������� ������ �� �������
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
        // ���������� ���������� ��� ������
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
            Debug.Log("���������� �����!");            // �������� �����
            Book.SetActive(true);            // ������� ������
            EndCurrentDialog();            // ���������� ���� ������������ �������
            dialogCompleted = true;
            puzzleSolved = true;
        }
        else
        {
            Debug.Log("������������ �����. ���������� ��� ���.");
            // �������� ��� ������������ ������        }
        }
    }
    private void Think()
    {
        Debug.Log("�������� ���.");
        EndCurrentDialog();
    }

}
