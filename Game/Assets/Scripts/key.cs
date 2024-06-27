using UnityEngine;

public class Key : MonoBehaviour
{
    public bool hasKey = false;

    public void PickUpKey()
    {
        hasKey = true;
    }
}
