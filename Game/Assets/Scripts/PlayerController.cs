//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerControler : MonoBehaviour
//{
//    public float moveSpeed = 5.0f; // ???????? ???????? ?????????

//    private CharacterController controller;

//    private void Start()
//    {
//        controller = GetComponent<CharacterController>();
//        //Cursor.lockState = CursorLockMode.Locked;
//        //Cursor.visible = false;
//    }

//    private void Update()
//    {
//        // ???????? ???? ?? ??????
//        float horizontalInput = Input.GetAxis("Horizontal");
//        float verticalInput = Input.GetAxis("Vertical");

//        // ????????? ??????????? ????????
//        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

//        // ????????? ??????????
//        moveDirection.y -= 9.81f * Time.deltaTime;

//        // ??????? ?????????
//        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float gravity = 9.81f; // Переменная для гравитации

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController not found on " + gameObject.name);
        }

        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    private void Update()
    {
        if (controller == null) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.y -= gravity * Time.deltaTime; // Используем переменную гравитации

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}