using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("KeyPress", true);

        
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("KeyPress", false);
    }
}
