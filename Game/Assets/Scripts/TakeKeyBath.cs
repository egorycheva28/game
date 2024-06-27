using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeKeyBath : MonoBehaviour
{
    public GameObject KeyBathRoom;
    public Door door;
    // Start is called before the first frame update 
    void Start()
    {
        KeyBathRoom.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                KeyBathRoom.SetActive(true);
                door.OpenDoor();
            }
        }
    }
}
