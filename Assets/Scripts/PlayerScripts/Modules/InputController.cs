using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script should only get input from the INPUT class
//and send to our modules
public class InputController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float mouseSensitivity;

    [Header("Modules")]
    [SerializeField] private ShootingModule shootingModule;
    [SerializeField] private InteractModule interactModule;
    [SerializeField] private MovementModule walkingModule;
    [SerializeField] private JumpModule jumpingModule;

    private bool jumping;
    private bool canLookWithMouse;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        camera.transform.localEulerAngles = transform.localEulerAngles;
        //This is only to fix an Unity bug in the current version
        Invoke("EnableMouseInput", 1f);
    }

    private void EnableMouseInput()
    {
        canLookWithMouse = true;
    }

    void Update()
    {
        Vector3 moveDirection = Vector2.zero;
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        Vector2 aimDirection = Vector2.zero;
        aimDirection.x = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        aimDirection.y = -Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        if (shootingModule != null && Input.GetMouseButtonDown(0))
        {
            shootingModule.Shoot();
        }

        if(interactModule != null && Input.GetKeyDown(KeyCode.E))
        {
            interactModule.InteractWithObject();
        }

        if(walkingModule != null)
        {
            walkingModule.MoveCharacter(moveDirection);
            walkingModule.RotateCharacter(aimDirection);
        }

        if(jumpingModule != null && Input.GetKeyDown(KeyCode.Space))
        {
            jumpingModule.Jump();
        }


    }

}
