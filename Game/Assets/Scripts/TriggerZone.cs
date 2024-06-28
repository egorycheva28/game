using UnityEngine;
public class TriggerZone : MonoBehaviour
{
    public Canvas canvasToShow;  // ������ �� ������, ������� ����� ��������
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasToShow.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasToShow.enabled = false;
        }
    }
}
