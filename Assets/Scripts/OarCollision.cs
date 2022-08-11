using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class OarCollision : MonoBehaviour
{
    private BehaviorTree sharkBehaviour;

    public bool hasDamagedBoat;

    ShipDamage shipDamage;

    [SerializeField] int damage = 1;

    private void Start()
    {
        shipDamage = FindObjectOfType<ShipDamage>();
    }

    private void Awake()
    {
        sharkBehaviour = GetComponent<BehaviorTree>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Oar"))
        {
            sharkBehaviour.SetVariableValue("isLeaving", true);
            Debug.Log("A shark has been hit by an oar and is leaving");
        }

        if (other.gameObject.CompareTag("Raft"))
        {
            Debug.Log("a shark has collided with the boat");
            if (!hasDamagedBoat)
            {
                shipDamage.raftHealth -= damage;
                hasDamagedBoat = true;
                Debug.Log("a shark has damaged with the boat");

            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Raft"))
        {
            hasDamagedBoat = false;
            Debug.Log("a shark has stopped colliding with the boat");

        }
    }
}
