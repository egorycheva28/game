using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    [SerializeField] Animator DoorAnimator;
    [SerializeField] bool Closed;

    public void TryOpen()
    {
        if (!Closed)
        {
            if (DoorAnimator.GetBool("interact") == false)
            {
                DoorAnimator.SetBool("interact", true);
            }
            else
            {
                DoorAnimator.SetBool("interact", false);
            }
        }
    }
    public void Unlock()
    {
        Closed = false;
    }
}