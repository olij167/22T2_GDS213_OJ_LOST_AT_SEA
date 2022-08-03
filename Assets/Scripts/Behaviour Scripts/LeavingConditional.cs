using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class LeavingConditional : Conditional
{
    public LeaveTimer leaveTimer;

    public override TaskStatus OnUpdate()
    {
        if (leaveTimer.isLeaving)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
