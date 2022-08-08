using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetAttackPoint : Action
{
    List<Transform> attackPointsList;

    public Transform attackTarget;

    public SetNewWaypoint waypoint;
    public override void OnAwake()
    {
        //AddAttackPoints();
        attackPointsList = new List<Transform>();

        //if (GameObject.FindGameObjectWithTag("Player"))
        //    attackPointsList.Add(GameObject.FindGameObjectWithTag("Player").transform);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("AttackPoint").Length; i++)
        {
            if (!attackPointsList.Contains(GameObject.FindGameObjectsWithTag("AttackPoint")[i].transform))
            {
                attackPointsList.Add(GameObject.FindGameObjectsWithTag("AttackPoint")[i].transform);
            }
        }

        SetNewAttackPoint();
    }


    public override TaskStatus OnUpdate()
    {
        if (attackTarget == null)
        {
            SetNewAttackPoint();
        }
        else
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }


    public void SetNewAttackPoint()
    {
        attackTarget = attackPointsList[Random.Range(0, attackPointsList.Count)];
    }
}
