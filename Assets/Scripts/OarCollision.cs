using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class OarCollision : MonoBehaviour
{
    private BehaviorTree sharkBehaviour;

    private void Awake()
    {
        sharkBehaviour = GetComponent<BehaviorTree>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oar"))
        {
            sharkBehaviour.SetVariableValue("isLeaving", true);
        }
    }
}
