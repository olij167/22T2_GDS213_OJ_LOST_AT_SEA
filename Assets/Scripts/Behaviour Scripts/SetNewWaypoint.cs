using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetNewWaypoint : Action
{
    public SharedTransform target;
    private Transform currentTarget;

    public Transform[] targetList;

    public SharedInt count, attackCount;

    public override void OnAwake()
    {
        count.SetValue(Random.Range(0, targetList.Length));
        
        targetList = new Transform[GameObject.FindGameObjectsWithTag("Waypoint").Length];

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Waypoint").Length; i++)
        {
            targetList[i] = GameObject.FindGameObjectsWithTag("Waypoint")[i].transform;
        }

        target.SetValue(targetList[Random.Range(0, targetList.Length)]);
        currentTarget = target.Value;

    }
    public override TaskStatus OnUpdate()
    {
        if (count.Value < targetList.Length)
        {
            count.Value++;
            attackCount.Value++;
            target.SetValue(targetList[count.Value]);
        }
        else if (count.Value >= targetList.Length)
        {
            count = 0;
            target.SetValue(targetList[count.Value]);
        }

        if (currentTarget != target.Value)
        {
            currentTarget = target.Value;
            return TaskStatus.Success;
        }
        

        return TaskStatus.Running;
    }
}
