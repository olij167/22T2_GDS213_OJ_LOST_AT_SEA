using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class WaypointReached : Conditional
{
    public SharedTransform target;

    float distanceFromWaypoint;

    public float withinWaypointDistance = 1f;

   

    public override TaskStatus OnUpdate()
    {
        //return base.OnUpdate();
        distanceFromWaypoint = Vector3.Distance(transform.position, target.Value.position);

        if (distanceFromWaypoint <= withinWaypointDistance)
        {

            return TaskStatus.Success;

        }

        return TaskStatus.Failure;
    }
}
