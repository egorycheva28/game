using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Camera mainCamera;  // Камера игрока 
    public KeyCode pickUpKey = KeyCode.E;  // Клавиша для поднятия ключа 
    public KeyCode dropKey = KeyCode.Q;  // Клавиша для броска ключа 
    public float throwForce = 10f;  // Сила броска 

    private Transform originalParent;
    private Rigidbody rb;
    public bool isHeld = false;
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
        transform.SetParent(mainCamera.transform);
        transform.localPosition = new Vector3(0.5f, -0.25f, 1.0f);
        transform.localRotation = Quaternion.identity;


        GetComponent<Collider>().enabled = false;
        rb.isKinematic = true;
    }

    private void DropKey()
    {
        isHeld = false;
        transform.SetParent(originalParent);

        transform.position = mainCamera.transform.position + mainCamera.transform.forward * 1.5f;
        transform.rotation = mainCamera.transform.rotation;

        GetComponent<Collider>().enabled = true;
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
}