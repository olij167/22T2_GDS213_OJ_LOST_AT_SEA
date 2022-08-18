using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    //// if stick pivot rotation y is < -90 && > 90
    //// rotate boat in the opposite direction of stick
    //// increase speed based on how close rotation is to limit

    [SerializeField] private float minRotation, maxRotation;
    [SerializeField] private float speed = 1f, rotationSpeed = 5f;
    [SerializeField] private Transform boat, stickPivot;
    //[SerializeField] private Vector3 rotationVector;
    //[SerializeField] private Quaternion rotation;

    void Update()
    {
        ////move forward
        boat.position += boat.forward * speed * Time.deltaTime;

        //// steer
        //rotationVector = new Vector3(0, stickPivot.localEulerAngles.y, 0);

        //Quaternion targetRotation = Quaternion.FromToRotation(boat.eulerAngles, stickPivot.localEulerAngles);

        Vector3 stickRotation = stickPivot.rotation.eulerAngles;
        stickRotation.y = (stickRotation.y > 180) ? stickRotation.y - 360 : stickRotation.y;
        stickRotation.y = Mathf.Clamp(stickRotation.y, minRotation, maxRotation);

        //Quaternion rotation = Quaternion.Euler(stickRotation);

        Vector3 boatRotation = new Vector3(0, boat.eulerAngles.y, 0);

        //boat.rotation = Quaternion.FromToRotation(boatRotation, stickRotation * rotationSpeed * Time.deltaTime);

        //boat.rotation = Quaternion.Euler(stickRotation * rotationSpeed * Time.deltaTime);

        boat.Rotate(-stickRotation * rotationSpeed * Time.deltaTime, 0, Space.Self);

        //LimitRotation();

    }

    private void LimitRotation()
    {
        


        //Quaternion rotationMin = new Quaternion(0, stickPivot.rotation.y - minRotation, 0, stickPivot.rotation.w);
        //Quaternion rotationMax = new Quaternion(0, stickPivot.rotation.y + maxRotation, 0, stickPivot.rotation.w);



        
    }
}






//boat.Rotate(rotationVector, rotationSpeed * Time.deltaTime);

//rotation = Quaternion.Euler(rotationVector);

//if (rotation.y > 180)
//{
//    rotation.y -= 360;
//}

//stickPivot.localEulerAngles = new Vector3(0, Mathf.Clamp(stickPivot.localEulerAngles.y, minRotation, maxRotation), 0);
