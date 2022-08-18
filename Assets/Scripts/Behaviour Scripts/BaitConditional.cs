using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class BaitConditional : Conditional
{
    public SharedBool baitInWater, isLeaving;
    
    public override TaskStatus OnUpdate()
    {
        if (baitInWater.Value && !isLeaving.Value)
        {
            return TaskStatus.Success;
        }


        return TaskStatus.Failure;
    }
}
