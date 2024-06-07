using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
    private NavMeshAgent agentToCommand;
    private Vector3 destination;
    public override void ExecuteCommand()
    {
        agentToCommand.SetDestination(destination);
    }

    public override bool IsCompleted()
    {
        return agentToCommand.remainingDistance < 0.2f;
    }

    public MoveCommand(NavMeshAgent agent, Vector3 targetPosition) 
    {
        destination = targetPosition;
        agentToCommand = agent;
    }
}
