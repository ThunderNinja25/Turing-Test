using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : AIState
{
    private float damageCooldownTimer;
    private Transform target;
    private HealthModule targetHealthModule;
    

    public override void OnStateEnter()
    {
        targetHealthModule = target.GetComponent<HealthModule>();
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateRun()
    {
        if(damageCooldownTimer >= 0)
        {
            //cooldown activated
            damageCooldownTimer += Time.deltaTime;
        }
        else
        {
            damageCooldownTimer = 3f;
            if(targetHealthModule != null)
            {
                targetHealthModule.Damage(5);
            }
        }


        

        if(Vector3.Distance(target.position, controller.transform.position) >= 3f)
        {
            controller.ChangeState(new ChaseState(target, controller));
        }
    }

    public AttackState(Transform newTarget, AIController con) : base(con)
    {
        controller = con;
        target = newTarget;
    }
}
