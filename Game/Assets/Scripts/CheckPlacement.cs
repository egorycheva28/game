using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    public GameObject flower; // ������, ������� ������ ���� �������� � ���� �����


    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("flower"))
        {
            Debug.Log("���������� ������ �� �����!");
            // ���������� ����������� ����������� ������
        }
    }
}
