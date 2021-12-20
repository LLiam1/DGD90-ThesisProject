using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    bool isClose;
    bool xClose; 
    bool yClose; 
    bool isCloseToTargetX;
    bool isCloseToTargetY;
    public float playerXDistVal = 2; 
    public float playerYDistVal = 8; 
    GameObject player;
    GameObject targetPoint;
    float playerX;
    float playerY;
    void Start()
    {
        isClose = false; 
        xClose = false;
        yClose = false;

        this.gameObject.tag = "Untagged";
    }

    // Update is called once per frame
    void Update(){
    player = GameObject.FindGameObjectWithTag("Player");
    playerX = player.transform.position.x;
    playerY = player.transform.position.y;
    Map();
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            targetPoint = GameObject.FindGameObjectWithTag("targetWaypoint");
            if(targetPoint == null){
            this.gameObject.tag = "targetWaypoint";
            return;
            }
            else{
            targetPoint.tag = "Untagged";
            this.gameObject.tag = "targetWaypoint";
            return;
            }
        }
    }

  

        

    void Map(){
            targetPoint = GameObject.FindGameObjectWithTag("targetWaypoint");
             if(targetPoint == null){
                 return;
            }
            

            //else{
            if(this.transform.position.x == targetPoint.transform.position.x &&
            this.transform.position.y != targetPoint.transform.position.y){
                this.gameObject.tag = ("onTargetX");
            }
            if(this.transform.position.x != targetPoint.transform.position.x &&
            this.transform.position.y == targetPoint.transform.position.y){
                this.gameObject.tag = ("onTargetY");
                //}
            }

                        
            if(this.transform.position.x != targetPoint.transform.position.x &&
            this.transform.position.y != targetPoint.transform.position.y){
                this.gameObject.tag = ("Untagged");
                //}
            }
        }

    }


