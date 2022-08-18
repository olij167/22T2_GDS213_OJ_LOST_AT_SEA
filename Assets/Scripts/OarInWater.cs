using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OarInWater : MonoBehaviour
{
    //when entering water get
    //get oar z rotation
    //get oar entry pos in water

    //while oar is in water && oar velocity > 0
    //add force in opposite direction
    //rotate boat to the left of oar movement direction

    [SerializeField] private Rigidbody oarRB;

    [SerializeField] private GameObject boat, boatRotationPivot;

    [SerializeField] private float power;

    [SerializeField] private Vector3 oarVelocity;
    [SerializeField] private Vector3 lastPos;
    [SerializeField] private Vector3 currentPos;
    //[SerializeField] private float worldDegrees;
    //[SerializeField] private float localDegrees;
    //[SerializeField] private float oarZRotation;

    [SerializeField] private float underWaterDrag = 3f;
    [SerializeField] private float underWaterAngularDrag = 1f;

    [SerializeField] private float airDrag = 0f;
    [SerializeField] private float airAngularDrag = 0.05f;

    [SerializeField] private bool isUnderwater;

    [SerializeField] private ForceMode forceMode;

    private void Update()
    {
        //oarZRotation = transform.localEulerAngles.z;

        if (isUnderwater)
        {

            StartCoroutine(CheckMovement());

            if (currentPos != lastPos) //oarVelocity.normalized != Vector3.zero
            {
                boat.GetComponent<Rigidbody>().AddForceAtPosition(-oarVelocity.normalized / underWaterDrag * power, boat.transform.position, forceMode);
                //boat.GetComponent<Rigidbody>().AddForce(-oarDirection.normalized * power);
                //boat.transform.RotateAround(boatRotationPivot.transform.position, Vector3.up, oarVelocity.magnitude * Time.deltaTime);

                Debug.Log("Adding force: " + oarVelocity.normalized / underWaterDrag * power);

            }

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ocean"))
        {
            isUnderwater = true;
            //waterEntryPos = transform.position;
            //lastPos = waterEntryPos;

            //oarVelocity = waterEntryPos - transform.position;

            SwitchDragType(isUnderwater);

            Debug.Log("Oar entered water");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ocean"))
        {
            isUnderwater = false;
            SwitchDragType(isUnderwater);

            //waterEntryPos = Vector3.zero;
            //oarDirection = Vector3.zero;
            //oarVelocity = Vector3.zero;

            Debug.Log("Oar left water");

        }
    }

    void SwitchDragType(bool isUnderwater)
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

    IEnumerator CheckMovement()
    {
        //currentPos = new Vector3(transform.localEulerAngles.y, transform.localEulerAngles.x, transform.localEulerAngles.z);
        currentPos = transform.position;

        oarVelocity = currentPos - lastPos;

        //worldDegrees = Vector3.Angle(Vector3.forward, oarVelocity.normalized); // angle relative to world space
        //localDegrees = Vector3.Angle(boat.transform.forward, oarVelocity.normalized); // angle relative to last heading of myobject

        //oarDirection = lastPos - currentPos;

        yield return new WaitForSeconds(1f);
        lastPos = currentPos;
    }
}

