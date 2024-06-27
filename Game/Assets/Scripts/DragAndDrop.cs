using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZCoord;
    private bool canMove = true; // ���������� ��� ����������/������� �����������

    void OnMouseDown()
    {
        if (!canMove)
            return; // ���� ����������� �������������, ������� �� ������

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
            return; // ���� ����������� �������������, ������� �� ������

        Vector3 newPos = GetMouseWorldPos() + mOffset;

        // ��������� ������������ � ������� ���������
        Collider[] colliders = Physics.OverlapBox(newPos, transform.localScale / 2f);
        foreach (Collider collider in colliders)
        {
            if (collider != GetComponent<Collider>())
            {
                // ���� ���������� ������������, �� ���������� ������
                return;
            }
        }

        transform.position = newPos;
    }

    // ����� ��� ���������� �����������
    public void LockMovement()
    {
        canMove = false;
    }

    // ����� ��� ������������� �����������
    public void UnlockMovement()
    {
        canMove = true;
    }
}
