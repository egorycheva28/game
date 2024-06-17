using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCoontroller : MonoBehaviour
{
    public float sensitivity = 2.0f; // Чувствительность мыши
    public float maxYAngle = 90.0f; // Максимальный угол вращения по вертикали

    private float rotationX = 0.0f;

    private void Update()
    {
        // Получаем ввод от мыши
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Вращаем персонажа в горизонтальной плоскости
        transform.parent.Rotate(Vector3.up * mouseX * sensitivity);

        // Вращаем камеру в вертикальной плоскости
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
}
