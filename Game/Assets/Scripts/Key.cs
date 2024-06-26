using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider))]


public class Key : MonoBehaviour
{
    public GameObject myPlayer;
    private float distance;
    public float interactDistance = 2f;

    public KeyCode myKey = KeyCode.E;

    //public Text myText;
    //public Image myImage;

    public GameObject openKey;

    void OnMouseOver()
    {
        distance = Vector3.Distance(myPlayer.GetComponent<Transform>().position, transform.position);
        if(distance < interactDistance )
        {
            //myText.enabled = true;
            //myImage.enabled = true;
            if(Input.GetKeyDown(myKey))
            {
                //openKey.GetComponent<Open>().key = true;
                //openKey.GetComponent<KeyMessage>().flag = false;
                //myText.enabled = false;
                //myImage.enabled = false;
                Destroy(gameObject);
            }
        }
        if(distance > interactDistance )
        {
            //myImage.enabled = false;
        }
    }

    void OnMouseExit()
    {
        //myText.enabled = false; 
        //myImage.enabled = false;
    }
}
