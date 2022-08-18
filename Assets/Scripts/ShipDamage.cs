using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamage : MonoBehaviour
{
    [SerializeField] public int raftHealth = 200;

    BuoyancyObject buoyancy;

    [SerializeField] private GameObject boat;
    [SerializeField] private Texture[] boatDamageTextures;

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

            boat.GetComponent<MeshRenderer>().material.mainTexture = boatDamageTextures[0];
        }
        
        if(raftHealth < 150 &&  raftHealth >= 100)
        {
            buoyancy.floatingPower = 600;
            boat.GetComponent<MeshRenderer>().material.mainTexture = boatDamageTextures[1];
        }
        
        if(raftHealth < 100 &&  raftHealth >= 50)
        {
            buoyancy.floatingPower = 500;
            boat.GetComponent<MeshRenderer>().material.mainTexture = boatDamageTextures[2];
        }
        
        if(raftHealth < 50 &&  raftHealth >= 10)
        {
            buoyancy.floatingPower = 400;
            boat.GetComponent<MeshRenderer>().material.mainTexture = boatDamageTextures[3];
        }
        
        if(raftHealth < 10 &&  raftHealth >= 1)
        {
            buoyancy.floatingPower = 200;
            boat.GetComponent<MeshRenderer>().material.mainTexture = boatDamageTextures[4];
        }
        
        if(raftHealth <= 0)
        {
            buoyancy.floatingPower = 0;
            boat.GetComponent<MeshRenderer>().material.mainTexture = boatDamageTextures[5];
        }


    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if(other.gameObject.tag == "Shark")
    //    {
    //        raftHealth -= 1;


    //    }
    //}
}
