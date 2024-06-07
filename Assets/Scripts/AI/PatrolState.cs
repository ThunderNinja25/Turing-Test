using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AIState
{
    [SerializeField] private int waypointIndex;
    [SerializeField] private float distanceToStop;
    public PatrolState(AIController con) : base(con)
    {

        controller = con;
        distanceToStop = 1;
    }

    public override void OnStateEnter()
    {
        controller.GetAgent().SetDestination(controller.GetWaypoint(waypointIndex).position);
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateRun()
    {
        //NO SIGHT OF PLAYER, NOT CLOSE TO PLAYER
        if (controller.GetAgent().remainingDistance < distanceToStop)
        {
            waypointIndex++;
            if (waypointIndex >= controller.TotalAmountOfWaypoints())
            {
                waypointIndex = 0;
            }
            controller.GetAgent().SetDestination(controller.GetWaypoint(waypointIndex).position);
        }
    }
}
