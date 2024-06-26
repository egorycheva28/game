using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum open_type_ENUM { rot_to_open, move_to_open } // ��� ����������
    public open_type_ENUM open_type;
    public enum door_axis_ENUM { X, Y, Z } // ��� ����������
    public door_axis_ENUM door_axis;
    public bool can_be_opened_now = false; // ����� �� ������� ������
    private bool is_open = false; // ���, ���� ��� �������
    public float open_speed = 150f; // �������� ����������
    public float open_dist_or_angle = 140f; // ���� ����������
    private float start_dist_or_angle;
    private bool open_close_ON = false;
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
                    {
                        transform.Rotate(open_dist_or_angle, 0, 0);
                        if (transform.localEulerAngles.x == start_dist_or_angle + open_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Y)
                    {
                        transform.Rotate(0, open_dist_or_angle, 0);
                        if (transform.localEulerAngles.y == start_dist_or_angle + open_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Z)
                    {
                        transform.Rotate(0, 0, open_dist_or_angle);
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
                        transform.Rotate(-open_dist_or_angle, 0, 0);
                        if (transform.localEulerAngles.x == start_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Y)
                    {
                        transform.Rotate(0, -open_dist_or_angle, 0);
                        if (transform.localEulerAngles.y == start_dist_or_angle)
                        {
                            Stop_open_close();
                        }
                    }
                    else if (door_axis == door_axis_ENUM.Z)
                    {
                        transform.Rotate(0, 0, -open_dist_or_angle);
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
            is_open = !is_open;
        }
        else
        {
            Debug.Log("Door cannot be opened now.");
        }
    }

    void Stop_open_close()
    {
        open_close_ON = false;
    }

    // ����� ��� �������� �����
    public void OpenDoor()
    {
        can_be_opened_now = true;
        Debug.Log("Door can now be opened.");
    }
}
