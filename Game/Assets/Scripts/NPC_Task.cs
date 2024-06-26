using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // �������� ��� ������ ��� ������������� TMP ���������
using UnityEngine.UI; // �������� ��� ������ ��� ������������� UI ���������

public class NPC_Task : MonoBehaviour
{
    public bool EndDialog;
    public GameObject Dialog1;
    public TMP_InputField AnswerInputField; // ���� ��� ����� ������
    public Button SubmitButton; // ������ ��� ������������� ������
    public string correctAnswer; // ���������� ����� �� �������

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

        // ���������� ��������� ��� ������
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
            Debug.Log("���������� �����!");
            // �������� ��� ���������� ������
            EndCurrentDialog();
            AnswerInputField.gameObject.SetActive(false);
            SubmitButton.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("������������ �����. ���������� ��� ���.");
            // �������� ��� ������������ ������
        }
    }
}
