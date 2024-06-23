//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Take : MonoBehaviour
//{
//    float distance = 10;

//    private void OnMouseDrag()
//    {
//        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
//        Vector3 objPos = Camera.main.ScreenToWorldPoint(mouse);
//        transform.position = objPos;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    [SerializeField] private float distance = 10f; // Теперь переменная доступна в инспекторе

    private void OnMouseDrag()
    {
        if (Camera.main != null)
        {
            Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPos = Camera.main.ScreenToWorldPoint(mouse);
            transform.position = objPos;
        }
    }
}