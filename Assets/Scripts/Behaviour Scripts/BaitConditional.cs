using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class BaitConditional : Conditional
{
    public SharedBool baitInWater;
    
    public override TaskStatus OnUpdate()
    {
        if (baitInWater.Value)
        {
            return TaskStatus.Success;
        }


        return TaskStatus.Failure;
    }
}
