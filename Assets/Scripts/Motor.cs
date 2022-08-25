using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    //// if stick pivot rotation y is < -90 && > 90
    //// rotate boat in the opposite direction of stick
    //// increase speed based on how close rotation is to limit

    //[SerializeField] private float minRotation, maxRotation;
    [SerializeField] private float speed = 1f, rotationSpeed = 5f;
    [SerializeField] private Transform stickPivot;
    [SerializeField] private Rigidbody boat;
    [SerializeField] private ForceMode force;

    [SerializeField] private float forceDistanceFromBoat;

    void Update()
    {

        ////move forward
        boat.transform.position += boat.transform.forward * speed * Time.deltaTime;

        //// steer
        float steerAngle = boat.transform.rotation.eulerAngles.y - stickPivot.rotation.eulerAngles.y;
        float xCorrectAngle = -boat.transform.rotation.eulerAngles.x;
        float zCorrectAngle = -boat.transform.rotation.eulerAngles.z;
        boat.transform.Rotate(xCorrectAngle * Time.deltaTime, steerAngle * Time.deltaTime, zCorrectAngle * Time.deltaTime);

        //stickRotation.y = (stickRotation.y > 180) ? stickRotation.y - 360 : stickRotation.y;

        //Vector3 stickPivotXZDirection = new Vector3(stickPivot.transform.position.x, 0, stickPivot.transform.position.z);

        //Vector3 boatNose = new Vector3(boat.transform.position.x + forceDistanceFromBoat, boat.transform.position.y, boat.transform.position.z);

        //boat.AddForceAtPosition(speed * stickPivotXZDirection, boatNose, force);
        //boat.transform.rotation = stickPivotXZDirection * rotationSpeed * Time.deltaTime;
        // Smoothly tilts a transform towards a target rotation.
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        //Quaternion target = Quaternion.Euler(0, stickPivot.rotation.y, 0);

        // Dampen towards the target rotation
        //transform.rotation = Quaternion.Slerp(boat.transform.rotation, target, Time.deltaTime * rotationSpeed);


        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)

        //x += Time.deltaTime * 10;
        //transform.rotation = Quaternion.Euler(x, 0, 0);

        //float turnAngle = boat.transform.rotation.eulerAngles.y - stickPivot.transform.eulerAngles.y;
        //Vector3 eulerAngleVelocity = new Vector3(0, 0, 0);
        //boat.transform.rotation = Quaternion.Euler(0,turnAngle * Time.deltaTime,0);
        
     

    }
}
