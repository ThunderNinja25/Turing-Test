using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.AI;

public class CommanderModule : MonoBehaviour
{
    [SerializeField] private float commandsRange = 5f;
    [SerializeField] private GameObject guidancePoint;
    [SerializeField] private NavMeshAgent minion;
    [SerializeField] private Queue<Command> commands = new Queue<Command>();
    [SerializeField] private Camera playerCam;
    [SerializeField] private LayerMask clickableFilter;

    private Command currentCommand;


    private void Update()
    {
        if (currentCommand != null && currentCommand.IsCompleted())
        {
            return;
        }
        if(commands.Count == 0)
        {
            return;
        }
        currentCommand = commands.Dequeue();
        currentCommand.ExecuteCommand();
    }

    public void CreateCommand()
    {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, commandsRange, clickableFilter))
        {
            Instantiate(guidancePoint, hit.point, Quaternion.identity);
            commands.Enqueue(new MoveCommand(minion, hit.point));
        }
        
    }
}
