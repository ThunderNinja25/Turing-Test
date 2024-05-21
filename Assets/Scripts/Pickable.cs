using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody myRigidbody;
    private FixedJoint joint;
    public void Interact(PlayerInput player)
    {
        if(transform.parent == null)
        {
            

            //joint = gameObject.AddComponent<FixedJoint>();
            //joint.connectedBody = player.GetPlayerRigidBody();
            myRigidbody.useGravity = false;
            myRigidbody.isKinematic = true;

            transform.SetParent(player.GetPickUpLocation());

            myRigidbody.position = player.GetPickUpLocation().position;
            //myRigidbody.rotation = player.GetPickUpLocation().rotation;
        }
        else
        {
            transform.SetParent(null);

            myRigidbody.useGravity = true;
            myRigidbody.isKinematic = false;
        }
        
    }

    public void OnHoverEnter()
    {
        
    }

    public void OnHoverExit()
    {
        
    }
}
