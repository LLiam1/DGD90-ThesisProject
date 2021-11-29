using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{

    public GameObject[] wayPoints;

    public GameObject closestPoint;

    public GameObject furthestPoint;

    void Start()
    {
        wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

        closestPoint = wayPoints[0];
        furthestPoint = wayPoints[0];
    }

    private void Update()
    {
        GetClosestWayPoint();
        GetFurthestWayPoint();
    }

    private void GetClosestWayPoint()
    {
        float length = 100000f;

        for (int i = 0; i <= wayPoints.Length - 1; i++)
        {
            float dist = Vector3.Distance(transform.position, wayPoints[i].transform.position);

            if(dist < length)
            {
                //Closer then previous
                closestPoint = wayPoints[i];

                length = dist;
            }

        }   
    }

    private void GetFurthestWayPoint()
    {
        float length = 0;

        for (int i = 0; i <= wayPoints.Length - 1; i++)
        {
            float dist = Vector3.Distance(transform.position, wayPoints[i].transform.position);

            if (dist > length)
            {
                //Closer then previous
                furthestPoint = wayPoints[i];

                length = dist;
            }

        }
    }
}
