using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamage : MonoBehaviour
{
    [SerializeField] public int raftHealth = 200;

    [SerializeField] public bool raftDamaged = false;
    [SerializeField] int numberOfFlashes = 3;
    [SerializeField] float flashDuration;
    [SerializeField] Material myMaterial;
    [SerializeField] Color originalColor;
    [SerializeField] Color flashColor;

    BuoyancyObject buoyancy;

    // Start is called before the first frame update
    void Start()
    {
        buoyancy = GetComponent<BuoyancyObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(raftHealth < 200 &&  raftHealth >= 150)
        {
            buoyancy.floatingPower = 750;
        }
        
        if(raftHealth < 150 &&  raftHealth >= 100)
        {
            buoyancy.floatingPower = 600;
        }
        
        if(raftHealth < 100 &&  raftHealth >= 50)
        {
            buoyancy.floatingPower = 500;
        }
        
        if(raftHealth < 50 &&  raftHealth >= 10)
        {
            buoyancy.floatingPower = 400;
        }
        
        if(raftHealth < 10 &&  raftHealth >= 1)
        {
            buoyancy.floatingPower = 200;
        }
        
        if(raftHealth <= 0)
        {
            buoyancy.floatingPower = 0;
        }


    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Shark")
    //    {
    //        if(raftDamaged)
    //        {
    //            raftHealth -= 0;
    //        } else
    //        {
    //            raftHealth -= 1;

    //        }
            

    //        StartCoroutine(FlashCo());
    //    }
    //}

    public IEnumerator FlashCo()
    {
        int temp = 0;
        raftDamaged = true;
        while (temp < numberOfFlashes)
        {
            myMaterial.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            myMaterial.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        raftDamaged = false;
    }

}
