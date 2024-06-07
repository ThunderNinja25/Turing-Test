using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractModule : MonoBehaviour
{
    [Header("Interactations")]
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Transform holdPoint;
    private IInteractable targetInteractable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
    }
    public void InteractWithObject()
    {
        if(targetInteractable != null)
        {
            //targetInteractable.OnInteract(this);
        }
        
    }
    private void CheckInteraction()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f, interactableLayer)) //SAYS THAT RAY COLLIDED WITH SOMETHING
        {
            if (targetInteractable == null)
            {
                targetInteractable = hit.collider.GetComponent<IInteractable>();
                targetInteractable.OnHoverEnter();
            }
        }
        else if (targetInteractable != null)
        {
            targetInteractable.OnHoverExit();
            targetInteractable = null;
        }
    }

    public Transform GetHoldTransform()
    {
        return holdPoint;
    }
}
