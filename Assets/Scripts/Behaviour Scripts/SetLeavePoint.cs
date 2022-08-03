using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetLeavePoint : Action
{
    public SharedTransform exitPoint;

    LightingManager lightingManager;
    public override void OnAwake()
    {
        lightingManager = GameObject.FindGameObjectWithTag("Time Cycle").GetComponent<LightingManager>();
    }

    public override TaskStatus OnUpdate()
    {
        if (lightingManager.spawnerList.Count >= 1 && exitPoint.Value == null)
        {
            exitPoint.SetValue(lightingManager.spawnerList[Random.Range(0, lightingManager.spawnerList.Count)].transform);
        }

        if (exitPoint != null)
        {
            return TaskStatus.Success;
        }
        

        return TaskStatus.Running;
    }
}
