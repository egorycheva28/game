using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Что-то вошло в триггер: " + other.gameObject.name);
    }
}
