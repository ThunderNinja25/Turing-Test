using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{

    [SerializeField] private Rigidbody rigidBody;
    private FixedJoint joint;

    public void Interact(PlayerInput interactor)
    {
        
        //rigidBody.useGravity = false;
        //rigidBody.isKinematic = true;
        if(joint == null)
        {
            joint = gameObject.AddComponent<FixedJoint>();
        }
        
        interactor.PickObject(this);
    }

    public void AttachToPlayer(Rigidbody rb)
    {
        if(joint != null)
        {
            joint.connectedBody = rb;
        }
    }

    public void OnHoverEnter()
    {
        
    }

    public void OnHoverExit()
    {
        
    }
}
