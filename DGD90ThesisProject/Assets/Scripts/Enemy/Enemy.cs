using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public RoomModule startRoom;

    public RoomModule endRoom;

    public List<RoomModule> currentPath = new List<RoomModule>();

    private Rigidbody2D rb;

    public enum EnemyStates { Idle, Moving, Attack };
    public EnemyStates state;

    public RoomModule currentRoom;

    private bool reachedlocation = true;

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
                MoveTowardsPlayer();
                break;

            //Idle State
            case EnemyStates.Idle:
                break;

            //Attack State
            case EnemyStates.Attack:
                break;
        }
    }


    private void MoveTowardsPlayer()
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
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Room")
        {
            currentRoom = collision.gameObject.GetComponent<RoomModule>();
        }   
    }
}
