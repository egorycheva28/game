using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    [SerializeField] KeyCode PickUp;
    public Door _Doorr;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.collider.tag == "Key")
            {
                if (Input.GetKey(PickUp))
                {
                    hit.collider.gameObject.GetComponent<KeyEvent>().UnlockDoor();
                }
            }
            if (hit.collider.tag == "Door")
            {
                if (Input.GetKey(PickUp))
                {
                    _Doorr.can_be_opened_now = true;
                    hit.collider.gameObject.GetComponent<DoorEvent>().TryOpen();
                }
            }
        }
    }
}

