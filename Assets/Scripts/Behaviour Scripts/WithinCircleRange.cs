using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class WithinCircleRange : Conditional
{
    public Transform player;

    public float distanceToCircle;

    public SharedBool inCircleRange;

    public override void OnAwake()
    {
        player = GameObject.FindGameObjectWithTag("Raft").transform;
    }

    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(transform.position, player.position) <= distanceToCircle)
        {
            inCircleRange.SetValue(true);
            return TaskStatus.Success;
        }
        else
        {
            inCircleRange.SetValue(false);
        }
        return TaskStatus.Failure;
    }
}
