using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour, IPuzzlePiece
{
    //[SerializeField] private List<Rigidbody> correctRigidbodies = new List<Rigidbody>();
    [SerializeField] private Rigidbody correctRigidBody;
    [SerializeField] private UnityEvent OnActivate;
    [SerializeField] private UnityEvent OnDeactivate;
    private bool IsCorrectRigidBodyOn;

    public bool IsCorrect { get => IsCorrectRigidBodyOn; set => IsCorrectRigidBodyOn = value; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody == correctRigidBody)
        {
            //DOOR WILL OPEN
            IsCorrectRigidBodyOn = true;
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
            IsCorrectRigidBodyOn = false;
            OnDeactivate.Invoke();
        }
    }
}
