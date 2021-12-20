using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    //Spawner Opening Direction
    public int openingDir;

    //Random Int
    private int rand;

    //Room Controller
    private RoomController roomController;


    //Game Controller
    private GameController gameController;

    //Has roomed spawned at this spawnpoint
    public bool isRoomSpawned = false;

    private void Start()
    {
        //Get Room Controller
        roomController = GameObject.FindGameObjectWithTag("RoomController").GetComponent<RoomController>();

        //Get Game Controller
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if (gameController.randomlyGenerateRooms)
        {
            //Start Room Spawning (Has a Time Delay of 1 second)
            Invoke("SpawnRooms", 0.5f);
        }
    }


    private void SpawnRooms()
    {
        if (gameController.randomlyGenerateRooms)
        {
            //Check If Room is NOT Spawned
            if (isRoomSpawned == false)
            {
                //Check Threshold
                if (roomController.currentRoomCount <= roomController.maxRooms)
                {
                    //Spawn Rooms to Connecting Point with Correct Entry Direction!
                    switch (openingDir)
                    {

                        //Spawn Top Entry
                        case 1:
                            //Get Random Room
                            rand = Random.Range(0, roomController.topRooms.Length);

                            //Instantiate Room
                            Instantiate(roomController.topRooms[rand], transform.position, roomController.topRooms[rand].transform.rotation, roomController.roomParent.transform);
                            break;
                        //Spawn Bottom Entry
                        case 2:
                            //Get Random Room
                            rand = Random.Range(0, roomController.bottomRooms.Length);

                            //Instantiate Room
                            Instantiate(roomController.bottomRooms[rand], transform.position, roomController.bottomRooms[rand].transform.rotation, roomController.roomParent.transform);
                            break;
                        //Spawn Right Entry
                        case 3:
                            //Get Random Room
                            rand = Random.Range(0, roomController.rightRooms.Length);

                            //Instantiate Room
                            Instantiate(roomController.rightRooms[rand], transform.position, roomController.rightRooms[rand].transform.rotation, roomController.roomParent.transform);
                            break;

                        //Spawn Left Entry
                        case 4:
                            //Get Random Room
                            rand = Random.Range(0, roomController.leftRooms.Length);

                            //Instantiate Room
                            Instantiate(roomController.leftRooms[rand], transform.position, roomController.leftRooms[rand].transform.rotation, roomController.roomParent.transform);
                            break;
                    }

                    //Set to True (Room has been spawned at this position)
                    isRoomSpawned = true;

                    //Increment the Room Count
                    roomController.currentRoomCount++;
                }
                else
                {
                    //Spawn a Closed Room (Since we are over the maxRooms)
                    Instantiate(roomController.closedRoom, transform.position, Quaternion.identity, roomController.roomParent.transform);

                    //Set to True (Room has been spawned at this position)
                    isRoomSpawned = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Prevent Rooms from Spawning on eachother
        if(collision == null)
        {
            return;
        }

        if (collision.CompareTag("SpawnPoint") && gameController.randomlyGenerateRooms)
        {
            //Return when Triggers a Destroyer on the Entry Room!
            if (collision.GetComponent<RoomSpawner>() == null)
            {
                return;
            }

            //Check if Openings
            if (collision.GetComponent<RoomSpawner>().isRoomSpawned == false && isRoomSpawned == false)
            {
                //Incase roomController is Null
                if(roomController == null)
                {
                    return;
                }

                //Spawn a Wall
                Instantiate(roomController.closedRoom, transform.position, Quaternion.identity, roomController.roomParent.transform);

                //Destroy Gameobject
                Destroy(gameObject);
            }
            //Room Has Been Spawned!
            isRoomSpawned = true;
        }
    }
}
