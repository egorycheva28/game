using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController myCC;

   

    public Transform AvatarCamera;
   // public Transform AvatarModel;

    public int movementSpeed;
    public float rotationSpeed;
    float xRotation = 0f;
    float yRotation = 0f;
    public float mouseX;
    public float mouseY;


    private Vector3 moveDirection = Vector3.zero;
    public float jumpSpeed = 8.0F;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpSpeed;

        }
        if (Input.GetButtonUp("Jump"))
        {
            moveDirection.y = 0;

        }
        myCC.Move(moveDirection * Time.deltaTime);
        BasicMovement();
        BasicRotation();
    }

    void BasicMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myCC.Move(transform.forward * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            myCC.Move(-transform.forward * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            myCC.Move(transform.right * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myCC.Move(-transform.right * Time.deltaTime * movementSpeed);
         
        }
    }

    void BasicRotation()
    {

        mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -70f, 70f); yRotation -= mouseY;
        mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        xRotation -= mouseX;
        AvatarCamera.transform.eulerAngles = new Vector3(yRotation, -xRotation, 0f);
    }
}
