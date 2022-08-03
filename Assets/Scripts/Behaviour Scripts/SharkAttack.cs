using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SharkAttack : Action
{
    GameObject raft;
    public float speed = 5f, distanceFromTarget, attackTimer;
    float attackTimerReset;

    public SharedInt attackCount;

    public override void OnAwake()
    {
        raft = GameObject.FindGameObjectWithTag("Raft");
        attackTimerReset = attackTimer;
    }
    public override TaskStatus OnUpdate()
    {
        //if (Vector3.Distance(transform.position, raft.transform.position) <= distanceFromTarget)
        //{
        //    attackCount.Value = 0;
        //    return TaskStatus.Success;
        //}
        //else
        //{

        //}

        if (attackTimer <= 0f)
        {
            attackTimer = attackTimerReset;
            return TaskStatus.Success;
        }

        attackTimer -= Time.deltaTime;

        //transform.position = Vector3.MoveTowards(transform.position, raft.transform.position, speed * Time.deltaTime);
        Vector3 waterHeightRaftPosition = new Vector3(raft.transform.position.x, transform.position.y, raft.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position , waterHeightRaftPosition, speed * Time.deltaTime);
        transform.LookAt(waterHeightRaftPosition);
        


        return TaskStatus.Running;
    }
}
