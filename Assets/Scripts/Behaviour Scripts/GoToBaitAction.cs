using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GoToBaitAction : Action
{
    public SharedTransform target, baitPos;

    public SharedTransformList baitList;

    public SharedBool baitInWater, isLeaving;

    float closest = 1000f;

    public float speed = 5f, distanceFromTarget = 1f, consumptionTimer = 5f;

    float timerReset;

    public override void OnStart()
    {
        timerReset = consumptionTimer;
    }

    public override TaskStatus OnUpdate()
    {
        if (baitList.Value != null && baitPos.Value == null)
            FindClosestBait();

        if (baitPos.Value != null)
        {
            if (Vector3.Distance(transform.position, baitPos.Value.transform.position) <= distanceFromTarget)
            {
                consumptionTimer -= Time.deltaTime;
            }
        }

        if (consumptionTimer <= 0f)
        {
            if (baitPos.Value != null)
            {
                GameObject.Destroy(baitPos.Value.gameObject);
                baitPos.Value = null;
            }
            else if (baitList.Value.Count > 0)
            {
                for (int i = 0; i < baitList.Value.Count; i++)
                {
                    if (baitList.Value[i] == null)
                    {
                        baitList.Value.RemoveAt(i);
                    }
                }

                FindClosestBait();
            }
        }

        if (baitPos.Value != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, baitPos.Value.position, speed * Time.deltaTime);
            transform.LookAt(baitPos.Value.position);
        }
        
        if (baitList.Value.Count <= 0)
        {
            consumptionTimer = timerReset;
            baitInWater.Value = false;

            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }

    public void FindClosestBait()
    {
        //Debug.Log("Finding Closest Bait");
        if (!isLeaving.Value)
        {

            for (int i = 0; i < baitList.Value.Count; i++)
            {
                if (baitList.Value[i] != null)
                {

                    baitPos.SetValue(baitList.Value[i]);
                    consumptionTimer = timerReset;

                    //float dist = Vector3.Distance(baitList.Value[i].position, gameObject.transform.position);

                    //if (dist < closest)
                    //{
                    //    closest = dist;
                    //    //Transform closestBait = baitList.Value[i];
                    //    baitPos.SetValue(baitList.Value[i]);
                    //    consumptionTimer = timerReset;

                    //    Debug.Log("Going to Closest Bait");

                    //}
                }
                else
                {
                    baitList.Value.RemoveAt(i);

                    if (baitList.Value.Count > 0)
                    {
                        FindClosestBait();
                    }
                    else
                    {
                        baitInWater.Value = false;
                    }
                }
            }
        }
        else
        {
            baitInWater.Value = false;
        }
    }
}
