using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform headUpDown;
    [SerializeField] private float movementSpeed;
    private Vector3 moveDirection;
    private Vector2 aimDirection;

    public void MoveCharacter(Vector3 direction)
    {
        moveDirection.x = direction.x;
        moveDirection.z = direction.z;

        float tempMultiplier = 1;

        controller.Move(((transform.right * moveDirection.x) + (transform.forward * moveDirection.z)) * Time.deltaTime * movementSpeed * tempMultiplier);
    }

    public void RotateCharacter(Vector3 direction)
    {
        aimDirection.x = direction.x;
        aimDirection.y += direction.y * Time.deltaTime;

        aimDirection.y = Mathf.Clamp(aimDirection.y, -85f, 85f);

        //IN CASE OF USING A NPC, NO NEED TO ROTATE HEAD UP AND DOWN
        //ONLY THE PLAYER CAN ROTATE UP AND DOWN
        //(assing camera to the HeadUpDown variable)

        if(headUpDown) headUpDown.localEulerAngles = new Vector3(aimDirection.y, 0, 0);

        //ROTATE THIS CHARACTER LEFT OR RIGHT (ON Y AXIS)
        transform.Rotate(Vector3.up, aimDirection.x * Time.deltaTime);
    }
}
