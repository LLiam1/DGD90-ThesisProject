using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public RoomModule startRoom;

    public RoomModule endRoom;

    public List<RoomModule> currentPath = new List<RoomModule>();

    private Rigidbody2D rb;

    public enum EnemyStates { Idle, Moving, Attack, Flee, Roam };
    public EnemyStates state;

    public RoomModule currentRoom;

    public bool reachedlocation = true;

    public float timer = 0;

    private const float IDLE_TIME = 2.5f;

    public RoomModule randRoom;

    public RoomController roomController;

    private bool roamRoomSet = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        //Switch Between Enemy States
        switch (state)
        {
            //Moving 
            case EnemyStates.Moving:
                //Move Towards Player
                StartCoroutine(ChasePlayer());
                break;

            //Idle State
            case EnemyStates.Idle:
                Idle();
                break;

            //Attack State
            case EnemyStates.Attack:
                break;

            case EnemyStates.Flee:
                Flee();
                break;
            case EnemyStates.Roam:
                Roam();
                break;

        }

        //If Room Light turns on! Flee to different room!
        if(!currentRoom.isLightOn)
        {
            state = EnemyStates.Flee;
        } 
    }



    private void Idle()
    {
        if(timer >= IDLE_TIME)
        {
            state = EnemyStates.Moving;
        } else
        {
            timer = timer + 1 * Time.deltaTime;
        }

    }

    IEnumerator ChasePlayer()
    {
        //Check if Location is Reached
        if (reachedlocation)
        {
            //Set Current Room
            startRoom = currentRoom;

            //Create a Path towards the player
            currentPath = Pathfinder.Pathfind(currentRoom, GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentRoom);
        }

        if (currentPath.Count > 0)
        {
            //Check if Reached Target
            if (Vector3.Distance(transform.position, currentPath[0].CurrentPos()) > 0.001)
            {
                float step = 5 * Time.deltaTime;

                //Move to Target Position
                transform.position = Vector2.MoveTowards(transform.position, currentPath[0].CurrentPos(), step);

                //Position Not Reached
                reachedlocation = false;
            }
            else
            {
                //Position Reached
                reachedlocation = true;

                //Removed From List because Location Reached
                currentPath.RemoveAt(0);
            }
        }
        else
        {
            state = EnemyStates.Idle;
            yield return null;
        }
    }


    private void Flee()
    {
        //Random Neighbor Room to Flee to
        RoomModule roomDest = currentRoom.theseNeighbors[0];

        //Clear Path
        currentPath.Clear();

        //Set Reached Destination to False
        reachedlocation = false;

        //Check if Reached Target
        if (Vector3.Distance(transform.position, roomDest.transform.position) > 0.001)
        {
            float step = 5 * Time.deltaTime;

            //Move to Target Position
            transform.position = Vector2.MoveTowards(transform.position, roomDest.transform.position, step);
        }
        else
        {
            //Position Reached
            reachedlocation = true;

            state = EnemyStates.Moving;

            timer = 0;
        }
    }

    private void Roam()
    {
        if(!roamRoomSet)
        {
            //Get Random Room
            int rand = UnityEngine.Random.Range(0, roomController.rooms.Count - 1);

            randRoom = roomController.rooms[rand].GetComponent<RoomModule>();

            //Random room is set
            roamRoomSet = true;
        } else
        {
            //Check if Location is Reached
            if (reachedlocation)
            {
                //Set Current Room
                startRoom = currentRoom;

                //Create a Path towards the player
                currentPath = Pathfinder.Pathfind(currentRoom, randRoom);
            }

            if (currentPath.Count > 0)
            {
                //Check if Reached Target
                if (Vector3.Distance(transform.position, currentPath[0].CurrentPos()) > 0.001)
                {
                    float step = 5 * Time.deltaTime;

                    //Move to Target Position
                    transform.position = Vector2.MoveTowards(transform.position, currentPath[0].CurrentPos(), step);

                    //Position Not Reached
                    reachedlocation = false;
                }
                else
                {
                    //Position Reached
                    reachedlocation = true;

                    //Removed From List because Location Reached
                    currentPath.RemoveAt(0);

                    roamRoomSet = false;
                    randRoom = null;
                }
            }
            else
            {
                state = EnemyStates.Moving;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Room")
        {
            currentRoom = collision.gameObject.GetComponent<RoomModule>();
        }

        //Player Collides with Enemy
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Lost");
        }
    }
}
