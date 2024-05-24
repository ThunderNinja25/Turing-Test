using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private AIController controller;
    [SerializeField] private LayerMask obstacles;

    private void OnTriggerEnter(Collider other)
    {
        if(Physics.Raycast(transform.position, other.transform.position, 10f, obstacles))
        {
            
        }
        controller.ChangeState(new ChaseState(other.transform, controller));
    }

    private void OnTriggerExit(Collider other)
    {
        controller.ChangeState(new PatrolState(controller));
    }
}
