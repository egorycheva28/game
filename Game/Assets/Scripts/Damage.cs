using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject item;
    public GameObject box;
    public float prob = 25;
    float rnd;

    private void OnMouseDown()
    {
        rnd = Random.Range(0, 100);
        if (rnd<=prob)
        {
            GameObject Item = Instantiate(item, transform.position, Quaternion.identity);
            Destroy(box);
        }
        else
        {
            Destroy(box); 
        }
    }
}
