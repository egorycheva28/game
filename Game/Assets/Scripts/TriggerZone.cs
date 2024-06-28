using UnityEngine;
public class TriggerZone : MonoBehaviour
{
    public Canvas canvasToShow;  // —сылка на канвас, который нужно показать
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
