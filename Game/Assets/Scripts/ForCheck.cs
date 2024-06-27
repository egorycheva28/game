using UnityEngine;

public class ForCheck : MonoBehaviour
{
    public Transform[] cubes;
    public Transform[] flowers;
    public GameObject bookObject; // Объект книги
    public float threshold = 0.1f; // Допуск для проверки касания

    private DragAndDrop[] flowerDragScripts; // Ссылки на скрипты DragAndDrop для цветков
    private bool allFlowersInPlace = false; // Флаг, указывающий на то, что все цветы на своих местах

    void Start()
    {
        // Получаем ссылки на скрипты DragAndDrop для всех цветков
        flowerDragScripts = new DragAndDrop[flowers.Length];
        for (int i = 0; i < flowers.Length; i++)
        {
            flowerDragScripts[i] = flowers[i].GetComponent<DragAndDrop>();
        }

        // Скрываем книгу при запуске сцены
        if (bookObject != null)
        {
            bookObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!allFlowersInPlace)
        {
            CheckFlowersOnCubes();
        }
    }

    void CheckFlowersOnCubes()
    {
        bool allInPlace = true;

        for (int i = 0; i < flowers.Length; i++)
        {
            Collider flowerCollider = flowers[i].GetComponent<Collider>();
            Collider cubeCollider = cubes[i].GetComponent<Collider>();

            // Проверка, что центр цветка находится на верхней границе куба с учетом допуска
            if (Mathf.Abs(flowerCollider.bounds.min.y - cubeCollider.bounds.max.y) < threshold &&
                flowerCollider.bounds.center.x > cubeCollider.bounds.min.x && flowerCollider.bounds.center.x < cubeCollider.bounds.max.x &&
                flowerCollider.bounds.center.z > cubeCollider.bounds.min.z && flowerCollider.bounds.center.z < cubeCollider.bounds.max.z)
            {
                Debug.Log("Flower " + (i + 1) + " is on top of Cube " + (i + 1));
                // Дополнительные действия, если цветок на верхней части куба
            }
            else
            {
                allInPlace = false;
            }
        }

        if (allInPlace)
        {
            allFlowersInPlace = true;
            Debug.Log("All flowers are in place. Movement locked for all flowers.");

            // Блокируем перемещение для всех цветков
            foreach (var script in flowerDragScripts)
            {
                script.LockMovement();
            }

            // Показываем книгу, если ее еще нет
            if (bookObject != null)
            {
                bookObject.SetActive(true);
            }
        }
    }
}

