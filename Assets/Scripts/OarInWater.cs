using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OarInWater : MonoBehaviour
{
    //get oar movement direction in water
    // add force in opposite direction
    // add torque to the left of the movement direction

    public Rigidbody oarRB;

    public float power;


    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;

    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;

    bool isUnderwater;

    public ForceMode forceMode;

    private void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ocean"))
        {
            isUnderwater = true;
            //Rigidbody oarRB = other.transform.parent.transform.parent.GetComponent<Rigidbody>();

            SwitchDragType(isUnderwater, oarRB);


            Vector3 direction = oarRB.velocity.normalized;

            oarRB.AddForceAtPosition((-direction + oarRB.velocity) * power , other.transform.position, forceMode);
            //oarRB.AddTorque(Vector3.left);
        }
    }

    void SwitchDragType(bool isUnderwater, Rigidbody oarRB)
    {
        if (isUnderwater)
        {
            oarRB.drag = underWaterDrag;
            oarRB.angularDrag = underWaterAngularDrag;
        }
        else
        {
            oarRB.drag = airDrag;
            oarRB.angularDrag = airAngularDrag;
        }
    }
}
