using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpModule : MonoBehaviour
{
    public const float gravityAcceleration = -9.81f;
    private Vector3 velocity;

    [SerializeField] private CharacterController controller;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask floorLayer;

    public void Jump()
    {
        if(IsGrounded() && controller)
        {
            velocity.y = jumpForce;
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.25f, floorLayer);
    }

    private void ApplyGravity()
    {
        if (!IsGrounded())
        {
            velocity.y += gravityAcceleration * Time.deltaTime;

            if (velocity.y < -9f)
            {
                velocity.y = -9f;
            }
        }
        else if (velocity.y < 0)
        {
            velocity.y = 0;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void Update()
    {
        ApplyGravity();
    }
}
