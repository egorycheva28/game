using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public GameObject itemPrefab;  // ������ ��������, ������� ������� 

    public GameObject box;         // ������ ������� 

    public float dropProbability = 25f;  // ����������� ��������� �������� � ��������� 

    private string bookTag = "Axe";  // ��� ��� ����� 

    private void OnMouseDown()
    {
        // ����� ����� �� ���� 
        GameObject book = GameObject.FindGameObjectWithTag(bookTag);
        if (book != null)
        {
            Take bookScript = book.GetComponent<Take>();
            // ��������, ��������� �� ����� � ����� ������ 
            if (bookScript != null && bookScript.IsHeld())
            {
                float randomValue = Random.Range(0f, 100f);
                if (randomValue <= dropProbability)
                {
                    Instantiate(itemPrefab, transform.position, Quaternion.identity);
                }
                Destroy(box);
            }
        }
    }
}
