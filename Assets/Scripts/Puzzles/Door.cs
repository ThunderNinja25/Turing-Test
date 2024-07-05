using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void OpenDoor()
    {
        animator.SetBool("KeyPress", true);
        
        
    }

    public void CloseDoor()
    {
        animator.SetBool("KeyPress", false);
        
    }

    public void DynamicOpenCloseDoor()
    {
        if (animator.GetBool("KeyPress"))
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }
    
}
