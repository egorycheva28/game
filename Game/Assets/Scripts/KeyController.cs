using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Camera mainCamera;  // Камера игрока
    public KeyCode pickUpKey = KeyCode.E;  // Клавиша для поднятия ключа
    public KeyCode dropKey = KeyCode.Q;  // Клавиша для броска ключа
    public float throwForce = 10f;  // Сила броска

    private Transform originalParent;  // Исходный родитель ключа
    private Rigidbody rb;  // Ссылка на Rigidbody компонента
    public bool isHeld = false;
    private bool isNear = false;  // Флаг, указывающий, находится ли игрок рядом с ключом

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        originalParent = transform.parent;  // Сохраняем исходного родителя

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true;  // Делаем Rigidbody кинематическим, чтобы предотвратить его влияние на физику пока объект поднят

        // Настраиваем коллайдер как триггер
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    void Update()
    {
        // Поднятие ключа
        if (isNear && !isHeld && Input.GetKeyDown(pickUpKey))
        {
            PickUpKey();
        }
        // Бросок ключа
        else if (isHeld && Input.GetKeyDown(dropKey))
        {
            DropKey();
        }
    }

    private void PickUpKey()
    {
        isHeld = true;
        transform.SetParent(mainCamera.transform);  // Делаем камеру родителем ключа
        transform.localPosition = new Vector3(0.5f, -0.5f, 1.0f);  // Смещение относительно камеры
        transform.localRotation = Quaternion.identity;  // Сбрасываем вращение

        // Отключаем коллайдер и делаем Rigidbody кинематическим, чтобы предотвратить дальнейшие взаимодействия
        GetComponent<Collider>().enabled = false;
        rb.isKinematic = true;
    }

    private void DropKey()
    {
        isHeld = false;
        transform.SetParent(originalParent);  // Возвращаем исходного родителя

        // Устанавливаем начальную позицию перед игроком
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * 1.5f;  // Смещение перед игроком
        transform.rotation = mainCamera.transform.rotation;  // Устанавливаем вращение в направлении камеры

        // Включаем коллайдер и отключаем кинематическое состояние для взаимодействий
        GetComponent<Collider>().enabled = true;
        rb.isKinematic = false;

        // Применяем силу броска вперед от камеры
        rb.AddForce(mainCamera.transform.forward * throwForce, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
        }
    }
}
