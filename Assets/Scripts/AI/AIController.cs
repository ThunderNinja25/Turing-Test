using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] targets;
    private AIState currentState;
    [SerializeField] private int waypointIndex;
    [SerializeField] private float distanceToStop;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new PatrolState(this));
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState != null)
        {
            currentState.OnStateRun();
        }
    }

    public void ChangeState(AIState state)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }
        
        currentState = state;

        currentState.OnStateEnter();
    }

    public Transform GetWaypoint(int index)
    {
        return targets[index];
    }

    public int TotalAmountOfWaypoints()
    {
        return targets.Length;
    }

    public Transform[] GetPathArray()
    {
        return targets;
    }

    public NavMeshAgent GetAgent()
    {
        return agent;
    }
}
