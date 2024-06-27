using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{

    public int number;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "Button1")
        {
            number = 1;
        }

        if (this.gameObject.name == "Button2")
        {
            number = 2;
        }

        if (this.gameObject.name == "Button3")
        {
            number = 3;
        }

        if (this.gameObject.name == "Button4")
        {
            number = 4;
        }
        if (this.gameObject.name == "Button5")
        {
            number = 5;
        }
        if (this.gameObject.name == "Button6")
        {
            number = 6;
        }
        if (this.gameObject.name == "Button7")
        {
            number = 7;
        }
        if (this.gameObject.name == "Button8")
        {
            number = 8;
        }
        if (this.gameObject.name == "Button9")
        {
            number = 9;
        }
        if (this.gameObject.name == "Button0")
        {
            number = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
