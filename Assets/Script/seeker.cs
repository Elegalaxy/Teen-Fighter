using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeker : MonoBehaviour
{
    public Transform distanceDetectLeft;
    public Transform distanceDetectRight;

    float rayDistance;
    float edgeDistanceLeft;
    float edgeDistanceRight;
    public bool isEmptyLeft;
    public bool isEmptyRight;
    bool startRay;

    Vector2 standoPosition;
    Vector2 targetPosition;
    Vector3 rayIncre;
    Vector2 rayLeftPoint;
    Vector2 rayRightPoint;
    public Vector3 orgLeft;
    public Vector3 orgRight;

    RaycastHit2D distanceRayLeft;
    RaycastHit2D distanceRayRight;

    private void Start()
    {
        rayDistance = 0.1f;
        rayIncre = new Vector3(0.5f, 0f, 0f);
        isEmptyLeft = false;
        isEmptyRight = false;
        orgLeft = distanceDetectLeft.position - transform.position;
        orgRight = distanceDetectRight.position - transform.position;
        Debug.Log(orgLeft);
        Debug.Log(orgRight);
        //distanceDetectLeft.position = transform.position + orgLeft;
        //distanceDetectRight.position = transform.position + orgRight;
        startRay = false;
    }

    private void Update()
    {
        if (startRay)
        {
            edgeDistanceLeft = 0f;
            edgeDistanceRight = 0f;
            //initialize raycast
            distanceRayLeft = Physics2D.Raycast(distanceDetectLeft.position, Vector2.down, rayDistance);
            distanceRayRight = Physics2D.Raycast(distanceDetectRight.position, Vector2.down, rayDistance);
            Debug.DrawRay(distanceDetectLeft.position, distanceRayLeft.collider.transform.position);
            Debug.DrawRay(distanceDetectRight.position, distanceRayRight.collider.transform.position, Color.red);
            Debug.Log(distanceRayLeft.collider.tag);
            //move the raycast
            if (!isEmptyLeft)
            {
                distanceDetectLeft.position -= rayIncre;
            }
            else
            {
                distanceDetectLeft.position = rayLeftPoint;
            }

            if (!isEmptyRight)
            {
                distanceDetectRight.position += rayIncre;
            }
            else
            {
                distanceDetectRight.position = rayRightPoint;
            }

            //checking edge position
            if (distanceRayLeft.collider.tag != "Player" && distanceRayLeft.collider.tag != "Ground" && distanceRayLeft.collider.tag != "Ladder")
            {
                isEmptyLeft = true;
                rayLeftPoint = distanceDetectLeft.position;
                edgeDistanceLeft = Vector2.Distance(transform.position, distanceDetectLeft.position);
            }

            if (distanceRayRight.collider.tag != "Player" && distanceRayRight.collider.tag != "Ground" && distanceRayRight.collider.tag != "Ladder")
            {
                isEmptyRight = true;
                rayRightPoint = distanceDetectRight.position;
                //Debug.Log(rayRightPoint);
                edgeDistanceRight = Vector2.Distance(transform.position, distanceDetectRight.position);
            }
            startRay = false;
        }
    }

    public Vector2 findPosition(Vector2[] positionList)
    {
        if(positionList != null) //players positions
        {
            standoPosition = transform.position; //get stando position
            targetPosition = positionList[0];

            float shortestDistance = Vector2.Distance(standoPosition, targetPosition); //count 1st distance

            for (int i = 1; i < positionList.Length; i++) //get closest player position
            {
                Vector2 checkPosition = positionList[i];
                if (Vector2.Distance(standoPosition, checkPosition) < shortestDistance)
                {
                    targetPosition = positionList[i];
                }
            }
        }
        return targetPosition; //return target player position
    }

    public Vector2 findDistance(Vector2 target)
    {
        Vector2 distance;
        float bodySize = 2f;
        float distanceLeft;
        float distanceRight;
        float targetDistanceLeft;
        float targetDistanceRight;

        startRay = true;
        targetDistanceLeft = Mathf.Abs(rayLeftPoint.x - target.x); //Vector2.Distance(rayLeftPoint, target);
        targetDistanceRight = Mathf.Abs(rayRightPoint.x - target.x); //Vector2.Distance(rayRightPoint, target);
        distanceLeft = edgeDistanceLeft + targetDistanceLeft;
        distanceRight = edgeDistanceRight + targetDistanceRight;
        
        if(distanceLeft < distanceRight)
        {
            rayLeftPoint.x -= bodySize;
            distance = rayLeftPoint;
        }
        else
        {
            rayRightPoint.x += bodySize;
            distance = rayRightPoint;
        }
        return distance;
    }
}
