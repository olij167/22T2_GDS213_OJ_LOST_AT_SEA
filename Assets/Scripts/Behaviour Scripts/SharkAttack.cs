using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SharkAttack : Action
{
    //GameObject raft;
    //GameObject player;
    //List<Transform> attackPointsList;

    public SetAttackPoint attackPoint;

    public float speed = 5f, distanceFromTarget, attackTimer;
    float attackTimerReset;

    public override void OnAwake()
    {
        //raft = GameObject.FindGameObjectWithTag("Raft");
        //player = GameObject.FindGameObjectWithTag("Player");

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

        if (attackTimer <= 0f || Vector3.Distance(transform.position, attackPoint.attackTarget.transform.position) <= distanceFromTarget)
        {
            attackPoint.attackTarget = null;
            attackTimer = attackTimerReset;
            return TaskStatus.Success;
        }

        attackTimer -= Time.deltaTime;

        //transform.position = Vector3.MoveTowards(transform.position, raft.transform.position, speed * Time.deltaTime);
        //Vector3 waterHeightRaftPosition = new Vector3(raft.transform.position.x, transform.position.y, raft.transform.position.z);
        //transform.position = Vector3.MoveTowards(transform.position , waterHeightRaftPosition, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position , attackPoint.attackTarget.position, speed * Time.deltaTime);
        transform.LookAt(attackPoint.attackTarget.position);
        


        return TaskStatus.Running;
    }
}
