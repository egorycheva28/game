using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEvent : MonoBehaviour
{
    [SerializeField] DoorEvent Door;
    public void UnlockDoor()
    {
        Door.Unlock();
        Destroy(gameObject);
    }
}
