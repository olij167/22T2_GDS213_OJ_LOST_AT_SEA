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

    void Update()
    {

        ////move forward
        boat.transform.position += boat.transform.forward * speed * Time.deltaTime;

        //// steer

        //stickRotation.y = (stickRotation.y > 180) ? stickRotation.y - 360 : stickRotation.y;

        boat.AddForceAtPosition(stickPivot.transform.forward * rotationSpeed * Time.deltaTime, stickPivot.transform.position, force);

    }
}
