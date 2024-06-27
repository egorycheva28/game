using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZCoord;
    private bool canMove = true; // Переменная для разрешения/запрета перемещения

    void OnMouseDown()
    {
        if (!canMove)
            return; // Если перемещение заблокировано, выходим из метода

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (!canMove)
            return; // Если перемещение заблокировано, выходим из метода

        Vector3 newPos = GetMouseWorldPos() + mOffset;

        // Проверяем столкновения с другими объектами
        Collider[] colliders = Physics.OverlapBox(newPos, transform.localScale / 2f);
        foreach (Collider collider in colliders)
        {
            if (collider != GetComponent<Collider>())
            {
                // Если обнаружено столкновение, не перемещаем объект
                return;
            }
        }

        transform.position = newPos;
    }

    // Метод для блокировки перемещения
    public void LockMovement()
    {
        canMove = false;
    }

    // Метод для разблокировки перемещения
    public void UnlockMovement()
    {
        canMove = true;
    }
}
