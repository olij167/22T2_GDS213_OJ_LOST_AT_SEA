using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class WaypointReached : Conditional
{
    public SharedTransform target;

    public float distanceFromWaypoint;

   

    public override TaskStatus OnUpdate()
    {
        //return base.OnUpdate();
        distanceFromWaypoint = Vector3.Distance(transform.position, target.Value.position);

        if (distanceFromWaypoint <= 0.5)
        {

            return TaskStatus.Success;

        }

        return TaskStatus.Failure;
    }
}
