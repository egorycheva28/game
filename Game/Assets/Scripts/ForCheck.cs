using UnityEngine;

public class ForCheck : MonoBehaviour
{
    public Transform[] cubes;
    public Transform[] flowers;
    public GameObject bookObject; // ������ �����
    public float threshold = 0.1f; // ������ ��� �������� �������

    private DragAndDrop[] flowerDragScripts; // ������ �� ������� DragAndDrop ��� �������
    private bool allFlowersInPlace = false; // ����, ����������� �� ��, ��� ��� ����� �� ����� ������

    void Start()
    {
        // �������� ������ �� ������� DragAndDrop ��� ���� �������
        flowerDragScripts = new DragAndDrop[flowers.Length];
        for (int i = 0; i < flowers.Length; i++)
        {
            flowerDragScripts[i] = flowers[i].GetComponent<DragAndDrop>();
        }

        // �������� ����� ��� ������� �����
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

            // ��������, ��� ����� ������ ��������� �� ������� ������� ���� � ������ �������
            if (Mathf.Abs(flowerCollider.bounds.min.y - cubeCollider.bounds.max.y) < threshold &&
                flowerCollider.bounds.center.x > cubeCollider.bounds.min.x && flowerCollider.bounds.center.x < cubeCollider.bounds.max.x &&
                flowerCollider.bounds.center.z > cubeCollider.bounds.min.z && flowerCollider.bounds.center.z < cubeCollider.bounds.max.z)
            {
                Debug.Log("Flower " + (i + 1) + " is on top of Cube " + (i + 1));
                // �������������� ��������, ���� ������ �� ������� ����� ����
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

            // ��������� ����������� ��� ���� �������
            foreach (var script in flowerDragScripts)
            {
                script.LockMovement();
            }

            // ���������� �����, ���� �� ��� ���
            if (bookObject != null)
            {
                bookObject.SetActive(true);
            }
        }
    }
}

