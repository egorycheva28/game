using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public static GameObject objectToCopy;

    public void SaveObject(GameObject obj)
    {
        objectToCopy = obj;
    }

    public GameObject GetObject()
    {
        return objectToCopy;
    }
}

