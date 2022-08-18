using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    [SerializeField] private float minRotation, maxRotation, speed = 10f, rotation;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform boat, stickPivot;
    [SerializeField] private Vector3 movementDirection;


    private void Start()
    {
        movementDirection = boat.forward;

    }



    void Update()
    {
        //float newRotation = rotation + stickPivot.eulerAngles.y * rotationSpeed * Time.deltaTime;
        rotation = stickPivot.rotation.y;
        //move forward
        boat.Rotate(0, -rotation, 0, Space.Self);
        boat.position += movementDirection * speed * Time.deltaTime;

        

        //steering
            //if stick pivot rotation y is < 0 && > 180
                //rotate boat to the right based on how close it is to -180
            //do the same for the other direction

        // turn right
        //if (stickPivot.localEulerAngles.y < 0 && stickPivot.localEulerAngles.y > minRotation)
        //{
        //    movementDirection = boat.forward;//  stickPivot.rotation;
        //}
        
        //// turn left
        //if (stickPivot.localEulerAngles.y > 0 && stickPivot.localEulerAngles.y < maxRotation)
        //{
        //    movementDirection = boat.forward - boat.right;
        //}

    }
}
