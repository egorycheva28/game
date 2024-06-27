using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeKeyBath : MonoBehaviour
{
    public GameObject KeyBathRoom;
    public Text pickupText;  

    // Start is called before the first frame update 
    void Start()
    {
        KeyBathRoom.SetActive(false);
        pickupText.enabled = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupText.enabled = true;  // Показываем текст, когда игрок заходит в коллайдер
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                KeyBathRoom.SetActive(true);
                pickupText.enabled = false; // Скрываем текст после взятия ключа
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupText.enabled = false; // Скрываем текст, когда игрок покидает коллайдер
        }
    }
}
