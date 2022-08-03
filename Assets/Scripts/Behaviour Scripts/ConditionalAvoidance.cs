using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class ConditionalAvoidance : Conditional
{
    public int isAvoidingObstacles;

    public ObstacleAvoidance obstacleAvoidance;

    public override TaskStatus OnUpdate()
    {
        if (obstacleAvoidance.avoidObstacle)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
