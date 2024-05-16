using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    private IInteractable selectedInteraction;

    private Vector3 moveDirection;
    private Vector2 lookDirection;

    [SerializeField] private Camera playerCam;

    [SerializeField] private Rigidbody projectile;

    [SerializeField] private Vector3 velocity;
    [SerializeField] private float bulletVelocity;

    [SerializeField] private Transform weaponTip;
    [SerializeField] private Transform pickupTip;

    private const float gravity = -9.81f;

    [SerializeField] private float speed;
    [SerializeField] private float lookSensitivity;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask layerFilter;
    [SerializeField] private LayerMask interactableFilter;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
        JumpPlayer();
        GravityCalculation();
        ShootWeapon();
        Interact();
    }

    private void Interact()
    {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f, interactableFilter)) //HIT SOMETHING ON RAYCAST
        {

            if(selectedInteraction == null) //BUT PREVIOUSLY DIDNT HAVE ANYTHING STORED
            {
                selectedInteraction = hit.collider.gameObject.GetComponent<IInteractable>();
                selectedInteraction.OnHoverEnter();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                selectedInteraction.Interact(this);
            }
        }
        else if (selectedInteraction != null) //IF DIDNT FIND ANYTHING
        {
            selectedInteraction.OnHoverExit();
            selectedInteraction = null;
        }
    }

    private void ShootWeapon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody projectileClone = Instantiate(projectile, weaponTip.position, weaponTip.rotation);
            projectileClone.AddForce(playerCam.transform.forward * bulletVelocity, ForceMode.Impulse);
            Destroy(projectileClone.gameObject, 3f);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, characterController.radius, layerFilter);
    }

    private void GravityCalculation()
    {
        
        if(!IsGrounded()) //THIS MEANS IM FALLING
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if(velocity.y <= 0)
        {
            velocity.y = -1f;
        }
        

        characterController.Move(velocity * Time.deltaTime);
    }

    private void MovePlayer()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        Vector3 moveForward = transform.forward * moveDirection.z;
        Vector3 moveRight = transform.right * moveDirection.x;

        float speedMultiplier = 1;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedMultiplier = sprintMultiplier;
        }

        characterController.Move((moveForward + moveRight) * Time.deltaTime * speed * speedMultiplier);
    }

    private void JumpPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
        {
            velocity.y = jumpForce;
        }
    }

    private void RotatePlayer()
    {
        lookDirection.x += Input.GetAxisRaw("Mouse X") * Time.deltaTime * lookSensitivity;
        lookDirection.y += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * lookSensitivity;


        lookDirection.y = Mathf.Clamp(lookDirection.y, -85f, 85f);

        playerCam.transform.localRotation = Quaternion.Euler(-lookDirection.y, 0, 0);

        transform.rotation = Quaternion.Euler(0, lookDirection.x, 0);
    }

    public void PickObject(Pickable pick)
    {
        pick.transform.position = pickupTip.position;
        pick.transform.rotation = pickupTip.rotation;
        pick.AttachToPlayer(characterController.attachedRigidbody);
    }

    public void DropObject(Pickable pick)
    {

    }
}
