using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("���-�� ����� � �������: " + other.gameObject.name);
    }
}
