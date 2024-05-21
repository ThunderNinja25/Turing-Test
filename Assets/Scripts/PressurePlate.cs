using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    //[SerializeField] private List<Rigidbody> correctRigidbodies = new List<Rigidbody>();
    [SerializeField] private Rigidbody correctRigidBody;
    [SerializeField] private UnityEvent OnActivate;
    [SerializeField] private UnityEvent OnDeactivate;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody == correctRigidBody)
        {
            //DOOR WILL OPEN
            OnActivate.Invoke();
        }

        /*
        if(correctRigidbodies.Contains(other.attachedRigidbody))
        {
            //DOOR WILL OPEN
            OnActivate.Invoke();
        }
        */
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.attachedRigidbody == correctRigidBody)
        {
            OnDeactivate.Invoke();
        }
    }
}
