using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public GameObject itemPrefab;  // Префаб предмета, который выпадет 

    public GameObject box;         // Объект сундука 

    public float dropProbability = 25f;  // Вероятность выпадения предмета в процентах 

    private string bookTag = "Axe";  // Тег для книги 

    private void OnMouseDown()
    {
        // Поиск книги по тегу 
        GameObject book = GameObject.FindGameObjectWithTag(bookTag);
        if (book != null)
        {
            Take bookScript = book.GetComponent<Take>();
            // Проверка, находится ли книга в руках игрока 
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
