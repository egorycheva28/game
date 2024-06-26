using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Material Red;
    public Material Blue;
    public Material Yellow;
    //in the editor this is what you would set as the object you wan't to change
    public GameObject Object;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer < 1) {
            Object.GetComponent<MeshRenderer>().material = Red;
            Timer += 0.1f;
        }
        if (Timer > 1 & Timer < 2) {
            Object.GetComponent<MeshRenderer>().material = Blue;
            Timer += 0.1f;
        }
        if (Timer > 2 & Timer < 3)
        {
            Object.GetComponent<MeshRenderer>().material = Yellow;
            Timer += 0.1f;
        }
        if (Timer > 3)
        {
            Timer = 0;
        }
    }
}
