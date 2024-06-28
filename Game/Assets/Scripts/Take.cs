using UnityEngine;

public class Take : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;  // Камера игрока 
    [SerializeField]
    private KeyCode pickUpKey = KeyCode.E;  // Клавиша для поднятия объекта 
    [SerializeField]
    private KeyCode dropKey = KeyCode.Q;  // Клавиша для броска объекта 
    [SerializeField]
    private float throwForce = 10f;  // Сила броска 

    private Transform originalParent;
    private Rigidbody rb;
    private Collider col;
    private bool isHeld = false;
    private bool isNear = false;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        originalParent = transform.parent;

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true;

        col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    void Update()
    {
        // Поднятие объекта 
        if (isNear && !isHeld && Input.GetKeyDown(pickUpKey))
        {
            PickUp();
        }
        // Бросок объекта 
        else if (isHeld && Input.GetKeyDown(dropKey))
        {
            Drop();
        }
    }

    private void PickUp()
    {
        isHeld = true;
        transform.SetParent(mainCamera.transform);
        transform.localPosition = new Vector3(0.5f, -0.25f, 1.0f);
        transform.localRotation = Quaternion.identity;

        col.enabled = false;
        rb.isKinematic = true;
    }

    private void Drop()
    {
        isHeld = false;
        transform.SetParent(originalParent);

        transform.position = mainCamera.transform.position + mainCamera.transform.forward * 1.5f;
        transform.rotation = mainCamera.transform.rotation;

        col.enabled = true;
        rb.isKinematic = false;

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

    // Метод для проверки, находится ли книга в руках игрока 
    public bool IsHeld()
    {
        return isHeld;
    }
}
