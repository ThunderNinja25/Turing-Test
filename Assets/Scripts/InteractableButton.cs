using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnButtonPressed;
    [SerializeField] private Material highlightedMaterial;

    private Material originalMaterial;
    private MeshRenderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<MeshRenderer>();
        originalMaterial = myRenderer.material;
        
    }



    public void Interact(PlayerInput player)
    {
        OnButtonPressed.Invoke();
        
    }

    public void OnHoverEnter()
    {
        myRenderer.material = highlightedMaterial;
        
    }

    public void OnHoverExit()
    {
        myRenderer.material = originalMaterial;
        
    }
}
