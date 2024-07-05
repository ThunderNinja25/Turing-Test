using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private CutsceneControl incompleteCutscene;
    public void Interact(PlayerInput player)
    {
        if(transform.parent == null)
        {
            myRigidbody.useGravity = false;
            myRigidbody.isKinematic = true;

            transform.SetParent(player.GetPickUpLocation());

            myRigidbody.position = player.GetPickUpLocation().position;
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
