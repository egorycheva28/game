using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    public GameObject flower; // Цветок, который должен быть размещен в этом круге


    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("flower"))
        {
            Debug.Log("Правильный цветок на месте!");
            // Остановите возможность перемещения цветка
        }
    }
}
