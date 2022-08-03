//Obstacle avoidance
//?amil Korkmaz, October 2021
//Public domain
//from: https://gist.github.com/samilkorkmaz/31b6c5e5dc9ceebf8febcc95a5a84f3b

using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class ObstacleAvoidance : Action
{
    public float maxSensingDistance = 5.0f;
    public float avoidDistanceFront = 1.0f;
    public float avoidDistanceSide = 3.0f;
    public float avoidanceTurnAngle_deg = 45.0f;
    public float incAngleMag_deg = 0.1f;

    GameObject hitObject = null;
    public bool avoidObstacle = false;
    float turnAngle_deg = 0;
    float incAngle_deg = 0;



    public override TaskStatus OnUpdate()
    {
        AvoidObstacle();

        if (avoidObstacle)
        {
            return TaskStatus.Running;
        }

        return TaskStatus.Failure;
    }

    private void AvoidObstacle()
    {
        Ray rayFrontRight = new Ray(transform.position + transform.right * 0.4f, transform.forward);
        Ray rayFrontLeft = new Ray(transform.position - transform.right * 0.4f, transform.forward);
        bool isObstacleInFront = CheckRay(rayFrontRight, avoidDistanceFront) || CheckRay(rayFrontLeft, avoidDistanceFront);
        if (isObstacleInFront && !avoidObstacle) //do not check left/right while avoidance maneuver is in progress
        {
            avoidObstacle = true;
            Ray rayRight = new Ray(transform.position, transform.right);
            bool isObstacleOnRight = CheckRay(rayRight, avoidDistanceSide);
            if (isObstacleOnRight)
            {
                Ray rayLeft = new Ray(transform.position, -transform.right);
                bool isObstacleOnLeft = CheckRay(rayLeft, avoidDistanceSide);
                if (isObstacleOnLeft)
                {
                    //TODO turn backwards
                }
                else incAngle_deg = -incAngleMag_deg;
            }
            else incAngle_deg = incAngleMag_deg;
        }
        if (avoidObstacle)
        {
            if (Mathf.Abs(turnAngle_deg) < avoidanceTurnAngle_deg) turnAngle_deg += incAngle_deg;
            else
            {
                turnAngle_deg = 0;
                avoidObstacle = false;
            }
            transform.Rotate(new Vector3(0, incAngle_deg, 0));
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 1f);
        }

    }

    private bool CheckRay(Ray ray, float avoidDistance)
    {
        RaycastHit hit;
        bool avoidObstacle = false;
        if (Physics.Raycast(ray, out hit, maxSensingDistance))
        {
            if (hit.transform.CompareTag("Shark"))
            {
                hitObject = hit.collider.gameObject;
                hitObject.GetComponent<Renderer>().material.color = Color.red;
                if (hit.distance < avoidDistance)
                {
                    avoidObstacle = true;
                    Debug.DrawLine(ray.origin, hit.point, Color.red);
                }
                else Debug.DrawLine(ray.origin, hit.point, Color.yellow);
            }
            //Debug.Log("Distance: " + hit.distance);
        }
        else
        {
            if (hitObject != null)
            {
                hitObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxSensingDistance, Color.green);
        }
        return avoidObstacle;
    }
}
