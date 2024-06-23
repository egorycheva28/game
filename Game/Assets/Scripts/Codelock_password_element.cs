using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codelock_password_element : MonoBehaviour
{
    [HideInInspector] public int current_number;
    public CodeLock _Codelock;

    void Start()
    {
        current_number = Random.Range(0, _Codelock.numbers_materials_AR.Length);
        GetComponent<MeshRenderer>().material = _Codelock.numbers_materials_AR[current_number];
    }


}