using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Добавьте эту строку для использования UI элементов
using TMPro; // Добавьте эту строку для использования TMP элементов
using UnityEngine.EventSystems;

public class Dialog_NextClick : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public TMP_InputField AnswerInputField;
    public Button SubmitButton;
    private bool isText1 = true;
    public NPC_Task npc_taskScript;

    // Use this for initialization
    void Start()
    {
        // Ensure Text1, Text2, AnswerInputField and SubmitButton are initialized properly
        if (Text1 == null || Text2 == null || AnswerInputField == null || SubmitButton == null)
        {
            Debug.LogError("One or more UI elements are not assigned.");
        }

        // Ensure npc_taskScript is initialized
        if (npc_taskScript == null)
        {
            npc_taskScript = FindObjectOfType<NPC_Task>();
            if (npc_taskScript == null)
            {
                Debug.LogError("NPC_Task script is not found in the scene.");
            }
        }

        // Initially hide AnswerInputField and SubmitButton
        AnswerInputField.gameObject.SetActive(false);
        SubmitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Проверяем, не был ли нажат TMP_InputField
            if (!EventSystem.current.IsPointerOverGameObject() || !AnswerInputField.gameObject.activeSelf)
            {
                if (isText1)
                {
                    isText1 = false;
                }
                else
                {
                    isText1 = true;
                    npc_taskScript.EndDialog = true;
                }
            }
        }

        if (isText1)
        {
            Text1.SetActive(true);
            Text2.SetActive(false);
            AnswerInputField.gameObject.SetActive(false);
            SubmitButton.gameObject.SetActive(false);
        }
        else
        {
            Text1.SetActive(false);
            Text2.SetActive(true);
            AnswerInputField.gameObject.SetActive(true);
            SubmitButton.gameObject.SetActive(true);
        }
    }
}
