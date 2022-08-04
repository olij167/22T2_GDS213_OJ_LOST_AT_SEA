using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveTowards : Action
{
    public SharedTransform target;

    Vector3 targetWaterLevel;

    public float speed = 5f, distanceFromTarget;

    public LeaveTimer leaveTimer;

    public SharedTransform exitPoint;
    public override TaskStatus OnUpdate()
    {
        if (leaveTimer.isLeaving.Value)
        {
            target.SetValue(exitPoint.Value);
        }

        if (Vector3.Distance(transform.position, target.Value.position) <= distanceFromTarget)
        {
            if (target == exitPoint)
            {
                UnityEngine.GameObject.Destroy(gameObject);
            }


            return TaskStatus.Success;
        }
        else
        {
            targetWaterLevel = new Vector3(target.Value.position.x, transform.position.y, target.Value.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetWaterLevel, speed * Time.deltaTime);
            transform.LookAt(targetWaterLevel);
        }
        

        return TaskStatus.Running;
    }

}
