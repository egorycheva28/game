using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ��� ������������� UI ��������� 
using TMPro; // ��� ������������� TMP ��������� 
using UnityEngine.EventSystems; // ��� ������������� EventSystem 

public class ManDialog : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public TMP_InputField AnswerInputField;
    public Button SubmitButton;
    public Button ThinkButton;
    private bool isText1 = true;
    public ManTask ManTaskScript;

    // Use this for initialization 
    void Start()
    {
        // Ensure Text1, Text2, AnswerInputField, SubmitButton, and ThinkButton are initialized properly 
        if (Text1 == null || Text2 == null || AnswerInputField == null || SubmitButton == null || ThinkButton == null) 
        {
            Debug.LogError("One or more UI elements are not assigned.");
        }

        // Ensure ManTaskScript is initialized 
        if (ManTaskScript == null)
        {
            ManTaskScript = FindObjectOfType<ManTask>();
            if (ManTaskScript == null)
            {
                Debug.LogError("ManTask script is not found in the scene.");
            }
        }

        // Initially hide AnswerInputField and SubmitButton 
        AnswerInputField.gameObject.SetActive(false);
        SubmitButton.gameObject.SetActive(false);
        ThinkButton.gameObject.SetActive(false);
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���������, �� ��� �� ����� TMP_InputField 
            if (!EventSystem.current.IsPointerOverGameObject() || !AnswerInputField.gameObject.activeSelf)
            {
                if (isText1)
                {
                    isText1 = false;
                }
                else
                {
                    isText1 = true;
                    ManTaskScript.EndDialog = true;
                }
            }
        }

        if (isText1)
        {
            Text1.SetActive(true);
            Text2.SetActive(false);
            AnswerInputField.gameObject.SetActive(false);
            SubmitButton.gameObject.SetActive(false);
            ThinkButton.gameObject.SetActive(false);
        }
        else
        {
            Text1.SetActive(false);
            Text2.SetActive(true);
            AnswerInputField.gameObject.SetActive(true);
            SubmitButton.gameObject.SetActive(true);
            ThinkButton.gameObject.SetActive(true);
        }
    }
}
