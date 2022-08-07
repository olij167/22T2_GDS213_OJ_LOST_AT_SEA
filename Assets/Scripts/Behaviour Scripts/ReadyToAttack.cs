using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class ReadyToAttack : Conditional
{
    //public SharedInt attackCount;
    public SetNewWaypoint waypoint;

    public int minRateOfAttack, maxRateOfAttack;
    public int rateOfAttack;

    public override void OnAwake()
    {
        rateOfAttack = Random.Range(minRateOfAttack, maxRateOfAttack);
    }
    public override TaskStatus OnUpdate()
    {

        if (waypoint.attackCount.Value % rateOfAttack == 0 && waypoint.attackCount.Value > 0f)
        {
            Debug.Log("Attacking");
            rateOfAttack = Random.Range(minRateOfAttack, maxRateOfAttack);
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
