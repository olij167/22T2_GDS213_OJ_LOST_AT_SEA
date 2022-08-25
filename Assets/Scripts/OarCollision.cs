using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.XR.Interaction.Toolkit;

public class OarCollision : MonoBehaviour
{
    private BehaviorTree sharkBehaviour;

    public int sharkHealth = 4;

    public bool hasDamagedBoat;

    ShipDamage shipDamage;

    [SerializeField] int damage = 1;

    [SerializeField] int numberOfFlashes = 3;
    [SerializeField] float flashDuration;
    [SerializeField] Material myMaterial;
    [SerializeField] Color originalColor;
    [SerializeField] Color flashColor;

    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip[] sharkClip;

    public ActionBasedController leftControl, rightControl;
    public float defaultAmplitud = 0.2f;
    public float defaultDuration = 0.5f;


    private void Start()
    {
        shipDamage = FindObjectOfType<ShipDamage>();
    }

    private void Awake()
    {
        sharkBehaviour = GetComponent<BehaviorTree>();
    }

    private void Update()
    {
        if (sharkHealth == 1)
        {
            sharkBehaviour.SetVariableValue("isLeaving", true);
        }
        if (sharkHealth <= 0)
        {
            GetComponent<BuoyancyObject>().enabled = false;
            sharkBehaviour.enabled = false;

            if (transform.position.y <= -3f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Oar"))
        {
            sharkHealth -= 1;
            SendHaptics();
            StartCoroutine(FlashShark());
            audiosource.PlayOneShot(sharkClip[Random.Range(0, sharkClip.Length)]);
            
            Debug.Log("A shark has been hit by an oar and is leaving");
        }

        if (other.gameObject.CompareTag("Raft"))
        {
            //Debug.Log("a shark has collided with the boat");
            if (!hasDamagedBoat)
            {
                if(shipDamage.raftDamaged)
                {
                    shipDamage.raftHealth -= 0;
                } else
                {
                    shipDamage.raftHealth -= damage;
                }
                StartCoroutine(shipDamage.FlashCo());
                hasDamagedBoat = true;
                //Debug.Log("a shark has damaged with the boat");

            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Raft"))
        {
            hasDamagedBoat = false;
            //Debug.Log("a shark has stopped colliding with the boat");

        }
    }

    IEnumerator FlashShark()
    {
        int temp = 0;
        while (temp < numberOfFlashes)
        {
            myMaterial.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            myMaterial.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
    }

    public void SendHaptics()
    {
        leftControl.SendHapticImpulse(defaultAmplitud, defaultDuration);
        rightControl.SendHapticImpulse(defaultAmplitud, defaultDuration);
    }

}
