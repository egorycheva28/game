using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour
{
    public GameObject flower;

    // Start is called before the first frame update
    void Start()
    {
        flower.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        flower.SetActive(StaticData.canTakeFlower1);
    }
}
