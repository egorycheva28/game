using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadScript : MonoBehaviour
{
    public int[] Code;
    public string CodeLength;
    private int Presses;
    private string result;

    private string ScreenText;
    public GameObject Screen;
    public string Correct;
    private int reset;

    public Door door; // Добавляем ссылку на объект двери 

    void Start()
    {
        if (string.IsNullOrEmpty(CodeLength))
        {
            Debug.LogError("CodeLength is not set!");
            return;
        }

        Code = new int[Convert.ToInt32(CodeLength)];
        Presses = 0;

        if (Screen == null)
        {
            Debug.LogError("Screen GameObject is not assigned!");
            return;
        }

        if (Screen.GetComponent<TextMeshPro>() == null)
        {
            Debug.LogError("Screen GameObject does not have a TextMeshPro component!");
            return;
        }

        if (door == null)
        {
            Debug.LogError("Door object is not assigned!");
            return;
        }
    }

    void Update()
    {
        if (Screen == null)
        {
            return;
        }

        ScreenText = string.Join("", Code.Select(i => i.ToString()).ToArray());
        Screen.GetComponent<TextMeshPro>().text = ScreenText;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10))
            {
                if (hit.transform == null)
                {
                    Debug.Log("No object hit by ray.");
                    return;
                }

                if (Presses < Convert.ToInt32(CodeLength))
                {
                    if (hit.transform.gameObject.name == "Base") { }
                    else
                    {
                        Debug.Log(hit.transform.gameObject.name);
                        Number numberComponent = hit.transform.gameObject.GetComponent<Number>();
                        if (numberComponent == null)
                        {
                            Debug.LogError("Number component not found on " + hit.transform.gameObject.name);
                            return;
                        }

                        Code[Presses] = numberComponent.number;
                        Presses += 1;
                    }
                }

                if (Presses == Convert.ToInt32(CodeLength))
                {
                    result = string.Join("", Code.Select(i => i.ToString()).ToArray());
                    Debug.Log("Entered Code: " + result);
                    if (Correct == result)
                    {
                        Debug.Log("The Code Entered Is Correct");
                        door.OpenDoor(); // Вызов метода открытия двери 
                    }
                    else
                    {
                        Debug.Log("The Code Entered Is Incorrect");
                        Presses = 0;
                        reset = Convert.ToInt32(CodeLength) - 1;
                        do
                        {
                            Code[reset] = 0;
                            reset -= 1;
                        } while (reset > -1);
                    }
                }
            }
        }
    }
}
