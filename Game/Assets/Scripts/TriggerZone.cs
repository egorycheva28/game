using UnityEngine;
public class TriggerZone : MonoBehaviour
{
    public GameObject panel;  // ������ �� GameObject ����� Panel
    void Start()
    {
        if (panel == null)
        {
            Debug.LogError("Panel is not assigned.");
        }
        else
        {
            panel.SetActive(false);  // ���������� �������� ������
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with " + other.gameObject.name);
        if (other.CompareTag("Player"))  // ��������������, ��� ����� ����� ��� "Player"
        {
            ShowPanel();
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called with " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            HidePanel();
        }
    }
    void ShowPanel()
    {
        Debug.Log("Showing Panel");
        panel.SetActive(true);  // �������� ������
    }
    void HidePanel()
    {
        Debug.Log("Hiding Panel");
        panel.SetActive(false);  // ��������� ������    
    }
}