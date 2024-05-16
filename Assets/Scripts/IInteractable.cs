using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact(PlayerInput interactor);
    

    public void OnHoverEnter();

    public void OnHoverExit();
    
}
