using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class LeaveTimer : Action
{
    public float leaveTimer, maxLeaveTimer, minLeaveTimer;

    public bool isLeaving;

    public override void OnAwake()
    {
        leaveTimer = Random.Range(minLeaveTimer, maxLeaveTimer);
    }

    public override TaskStatus OnUpdate()
    {
        leaveTimer -= Time.deltaTime;

        if (leaveTimer <= 0f)
        {
            isLeaving = true;
            return TaskStatus.Success;
        }

        isLeaving = false;
        return TaskStatus.Running;
    }
}
