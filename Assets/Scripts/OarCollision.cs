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

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Oar"))
        {
            sharkBehaviour.SetVariableValue("isLeaving", true);
        }
    }
}
