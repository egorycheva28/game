using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;            // Скорость движения игрока
    public float mouseSensitivity = 100.0f;  // Чувствительность мыши
    public float jumpHeight = 2.0f;       // Высота прыжка
    public float gravity = -9.81f;        // Гравитация
    public float crouchHeight = 1.0f;     // Высота при приседании
    public float maxYAngle = 90.0f; // Максимальный угол вращения по вертикали

    private CharacterController characterController;
    private Transform playerCameraTransform;

    private float xRotation = 0.0f;       // Текущая ротация по оси X
    private Vector3 velocity;             // Вектор для хранения скорости движения
    private bool isGrounded;              // Проверка на нахождение на земле
    private float originalHeight;         // Исходная высота капсулы

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;  // Закрыть курсор в центре экрана
        characterController = GetComponent<CharacterController>();  // Получаем компонент CharacterController
        //playerCameraTransform = transform.Find("PlayerCamera");  // Ищем камеру как дочерний объект

        /*if (characterController == null)
        {
            Debug.LogError("CharacterController не найден на объекте Player. Пожалуйста, добавьте его.");
        }

        if (playerCameraTransform == null)
        {
            Debug.LogError("PlayerCamera не найден как дочерний объект Player. Пожалуйста, убедитесь, что камера названа правильно.");
        }*/

        originalHeight = characterController.height;  // Сохраняем исходную высоту капсулы
    }

    void Update()
    {
        // Движение мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Поворачиваем камеру по оси X (вверх/вниз)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);  // Ограничение на вращение вверх/вниз
        playerCameraTransform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

        // Поворачиваем тело игрока по оси Y (влево/вправо)
        transform.Rotate(Vector3.up * mouseX);

        // Движение игрока
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * speed * Time.deltaTime);  // Движение через CharacterController

        // Проверка на нахождение на земле
        isGrounded = characterController.isGrounded;

        // Добавление гравитации
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Устанавливаем небольшое отрицательное значение, чтобы персонаж оставался на земле
        }

        // Прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Приседание
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            characterController.height = crouchHeight; // Уменьшаем высоту для приседания
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            characterController.height = originalHeight; // Восстанавливаем исходную высоту
        }

        // Применение гравитации
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);  // Применение скорости движения к CharacterController
    }
}