using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;            // �������� �������� ������
    public float mouseSensitivity = 100.0f;  // ���������������� ����
    public float jumpHeight = 2.0f;       // ������ ������
    public float gravity = -9.81f;        // ����������
    public float crouchHeight = 1.0f;     // ������ ��� ����������
    public float maxYAngle = 90.0f; // ������������ ���� �������� �� ���������

    private CharacterController characterController;
    private Transform playerCameraTransform;

    private float xRotation = 0.0f;       // ������� ������� �� ��� X
    private Vector3 velocity;             // ������ ��� �������� �������� ��������
    private bool isGrounded;              // �������� �� ���������� �� �����
    private float originalHeight;         // �������� ������ �������

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;  // ������� ������ � ������ ������
        characterController = GetComponent<CharacterController>();  // �������� ��������� CharacterController
        //playerCameraTransform = transform.Find("PlayerCamera");  // ���� ������ ��� �������� ������

        /*if (characterController == null)
        {
            Debug.LogError("CharacterController �� ������ �� ������� Player. ����������, �������� ���.");
        }

        if (playerCameraTransform == null)
        {
            Debug.LogError("PlayerCamera �� ������ ��� �������� ������ Player. ����������, ���������, ��� ������ ������� ���������.");
        }*/

        originalHeight = characterController.height;  // ��������� �������� ������ �������
    }

    void Update()
    {
        // �������� ����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ������������ ������ �� ��� X (�����/����)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);  // ����������� �� �������� �����/����
        playerCameraTransform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

        // ������������ ���� ������ �� ��� Y (�����/������)
        transform.Rotate(Vector3.up * mouseX);

        // �������� ������
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * speed * Time.deltaTime);  // �������� ����� CharacterController

        // �������� �� ���������� �� �����
        isGrounded = characterController.isGrounded;

        // ���������� ����������
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // ������������� ��������� ������������� ��������, ����� �������� ��������� �� �����
        }

        // ������
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // ����������
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            characterController.height = crouchHeight; // ��������� ������ ��� ����������
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            characterController.height = originalHeight; // ��������������� �������� ������
        }

        // ���������� ����������
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);  // ���������� �������� �������� � CharacterController
    }
}
