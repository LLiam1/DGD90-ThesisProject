using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{    
    float moveSpeed;
    public float defaultSpeed;
    public GameObject startPos;

    public float rageDist; 
    public float rageSpeed; 

    int currentWaypointVal;

    GameObject player;

    public List<Transform> waypointList; 

    Transform previousWaypoint;

    public enum EnemyState{
        Close,
        Far,
        Chase
    }

    EnemyState currentState;
        void Start()
    {
        //transform.position = waypoints [waypointIndex].transform.position;
        currentState = EnemyState.Far;
        moveSpeed = defaultSpeed;
        currentWaypointVal = 0; 
        waypointList.Add(startPos.transform);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Transform enemyPos = this.transform;

        GameObject xTarget = GameObject.FindGameObjectWithTag("onTargetX");
        GameObject yTarget = GameObject.FindGameObjectWithTag("onTargetY");
        
        if(xTarget == null){
            if(yTarget == null){
                return;
            }
        
            else{
                return; 
            }
        }

        if(yTarget == null){
            if(xTarget == null){
                return;
            }
            else{
                return;
            }
        }

        float playerDist = Vector2.Distance(this.gameObject.transform.position, 
                                        player.transform.position);

        float xEnemyDist = Vector2.Distance(this.gameObject.transform.position,
                                        xTarget.transform.position);

        float yEnemyDist = Vector2.Distance(this.gameObject.transform.position,
                                        yTarget.transform.position);

        GameObject finishPoint = GameObject.FindGameObjectWithTag("targetWaypoint");

        switch(currentState)
        {
            case EnemyState.Far:
            moveSpeed = defaultSpeed;
                if(xEnemyDist < yEnemyDist){
                    waypointList.Add(yTarget.transform);  
                }
            
                
                if(xEnemyDist > yEnemyDist){
                        waypointList.Add(xTarget.transform);
                }
                break;
            

            case EnemyState.Close:
                waypointList.Add(finishPoint.transform);
            break;

            case EnemyState.Chase:
            moveSpeed = rageSpeed;
            waypointList.Add(player.transform);
            break;
        }

        

        if(enemyPos.transform.position == xTarget.transform.position 
        || enemyPos.transform.position == yTarget.transform.position){
            currentState = EnemyState.Close;
        }     

        if(enemyPos.transform.position == finishPoint.transform.position){
            if(rageDist <= playerDist){
                //currentState = EnemyState.Chase;
            }
            else{
                currentState = EnemyState.Far;
            }
            
        }


        Debug.Log(currentWaypointVal);
        Transform currentWaypoint = (waypointList[currentWaypointVal]);

        //previousWaypoint = waypointList[currentWaypointVal - 1];

        Move(waypointList[currentWaypointVal]);
        if(enemyPos.transform.position == waypointList[currentWaypointVal].position){
            if(currentWaypointVal >= waypointList.Count){
                currentWaypointVal = 0;
            }
            if(currentWaypointVal < waypointList.Count){
                currentWaypointVal++;
            }  
            
        }
    }

    void Move(Transform target){
        

        transform.position = Vector2.MoveTowards(transform.position, 
        target.transform.position, moveSpeed * Time.deltaTime);

    //     if(transform.position == waypoints[waypointIndex].transform.position){
    //         waypointIndex += 1;
    //     }

    //     if(waypointIndex == waypoints.Length){
    //         waypointIndex = 0;
    //     }
    }
        }
    


