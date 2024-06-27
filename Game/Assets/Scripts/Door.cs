using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum open_type_ENUM { rot_to_open, move_to_open }//тип открывания
    public open_type_ENUM open_type;
    public enum door_axis_ENUM { X, Y, Z }//ось открывания
    public door_axis_ENUM door_axis;
    public bool can_be_opened_now;//можно ли открыть сейчас
    private bool is_open;//тру, если уже открыта
    public float open_speed = 150f;//скорость открывания
    public float open_dist_or_angle = 140f;//угол открывания
    private float start_dist_or_angle;
    private bool open_close_ON;
    public GameObject image;

    void Start()
    {
        if (open_type == open_type_ENUM.move_to_open)
        {
            if (door_axis == door_axis_ENUM.X)
            {
                start_dist_or_angle = transform.localPosition.x;
            }
            else if (door_axis == door_axis_ENUM.Y)
            {
                start_dist_or_angle = transform.localPosition.y;
            }
            else if (door_axis == door_axis_ENUM.Z)
            {
                start_dist_or_angle = transform.localPosition.z;
            }
        }
        else
        {
            if (door_axis == door_axis_ENUM.X)
            {
                start_dist_or_angle = transform.localEulerAngles.x;
            }
            else if (door_axis == door_axis_ENUM.Y)
            {
                start_dist_or_angle = transform.localEulerAngles.y;
            }
            else if (door_axis == door_axis_ENUM.Z)
            {
                start_dist_or_angle = transform.localEulerAngles.z;
            }
        }
    }

    void OnMouseEnter()
    {
        if (gameObject.tag == "Door")
        {
            image.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (gameObject.tag == "Door")
        {
            image.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        Open_close();
    }

    void Update()
    {
        if (open_close_ON)
        {
            if (is_open)
            {
                if (open_type == open_type_ENUM.move_to_open)
                {
                    if (door_axis == door_axis_ENUM.X)
                    {
                        float posX = Mathf.MoveTowards(transform.localPosition.x, start_dist_or_angle + open_dist_or_angle, open_speed * Time.deltaTime);
                        transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
                        if (transform.localPosition.x == start_dist_or_angle + open_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Y)
                    {
                        float posY = Mathf.MoveTowards(transform.localPosition.y, start_dist_or_angle + open_dist_or_angle, open_speed * Time.deltaTime);
                        transform.localPosition = new Vector3(transform.localPosition.x, posY, transform.localPosition.z);
                        if (transform.localPosition.y == start_dist_or_angle + open_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Z)
                    {
                        float posZ = Mathf.MoveTowards(transform.localPosition.z, start_dist_or_angle + open_dist_or_angle, open_speed * Time.deltaTime);
                        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, posZ);
                        if (transform.localPosition.z == start_dist_or_angle + open_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                }
                else
                {
                    if (door_axis == door_axis_ENUM.X)
                    {//float angleX = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, start_dist_or_angle + open_dist_or_angle, open_speed * Time.deltaTime);
                        transform.Rotate(open_dist_or_angle, 0, 0);
                        //transform.Rotate(transform.up * open_dist_or_angle * Time.deltaTime);
                        //transform.localPosition = new Vector3(angleX,0,0);
                        if (transform.localEulerAngles.x == start_dist_or_angle + open_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Y)
                    {
                        //float angleY = Mathf.MoveTowardsAngle(transform.localEulerAngles.y, start_dist_or_angle + open_dist_or_angle, open_speed * Time.deltaTime);              
                        transform.Rotate(0, open_dist_or_angle, 0);
                        //transform.Rotate(transform.up * open_dist_or_angle * Time.deltaTime);
                        //transform.localPosition = new Vector3(0,angleY,0);
                        if (transform.localEulerAngles.y == start_dist_or_angle + open_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Z)
                    {
                        transform.Rotate(0, 0, open_dist_or_angle);
                        //float angleZ = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, start_dist_or_angle + open_dist_or_angle, open_speed * Time.deltaTime);
                        //transform.Rotate(transform.up * angleZ * Time.deltaTime);
                        //transform.localPosition = new Vector3(0,0,angleZ);
                        if (transform.localEulerAngles.z == start_dist_or_angle + open_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                }
            }
            else
            {
                if (open_type == open_type_ENUM.move_to_open)
                {
                    if (door_axis == door_axis_ENUM.X)
                    {
                        float posX = Mathf.MoveTowards(transform.localPosition.x, start_dist_or_angle, open_speed * Time.deltaTime);
                        transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
                        if (transform.localPosition.x == start_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Y)
                    {
                        float posY = Mathf.MoveTowards(transform.localPosition.y, start_dist_or_angle, open_speed * Time.deltaTime);
                        transform.localPosition = new Vector3(transform.localPosition.x, posY, transform.localPosition.z);
                        if (transform.localPosition.y == start_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Z)
                    {
                        float posZ = Mathf.MoveTowards(transform.localPosition.z, start_dist_or_angle, open_speed * Time.deltaTime);
                        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, posZ);
                        if (transform.localPosition.z == start_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                }
                else
                {
                    if (door_axis == door_axis_ENUM.X)
                    {
                        //float angleX = Mathf.MoveTowardsAngle(transform.localEulerAngles.x, start_dist_or_angle, open_speed * Time.deltaTime);
                        transform.Rotate(-open_dist_or_angle, 0, 0);
                        //transform.localPosition = new Vector3(angleX, 0, 0);
                        if (transform.localEulerAngles.x == start_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Y)
                    {
                        //float angleY = Mathf.MoveTowardsAngle(transform.localEulerAngles.y, start_dist_or_angle, open_speed * Time.deltaTime);
                        transform.Rotate(0, -open_dist_or_angle, 0);
                        //transform.localPosition = new Vector3(0, angleY, 0);
                        if (transform.localEulerAngles.y == start_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Z)
                    {
                        //float angleZ = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, start_dist_or_angle, open_speed * Time.deltaTime);
                        transform.Rotate(0, 0, -open_dist_or_angle);
                        //transform.localPosition = new Vector3(0, 0, angleZ);
                        if (transform.localEulerAngles.z == start_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                }
            }
        }
    }

    void Open_close()
    {
        if (can_be_opened_now)
        {
            open_close_ON = true;
            if (is_open)
            {
                is_open = false;
            }
            else
            {
                is_open = true;

            }
        }

    }

    void Stop_open_close()
    {
        open_close_ON = false;
    }

    // Метод для открытия двери
    public void OpenDoor()
    {
        can_be_opened_now = true;
        Debug.Log("Door can now be opened.");
    }
}