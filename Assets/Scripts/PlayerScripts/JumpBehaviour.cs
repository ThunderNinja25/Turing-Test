using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask layerFilter;
    [SerializeField] private float jumpForce;
    public void JumpPlayer()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime);
            //velocity.y = jumpForce;
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, groundCheckRadius, layerFilter);
    }
}
