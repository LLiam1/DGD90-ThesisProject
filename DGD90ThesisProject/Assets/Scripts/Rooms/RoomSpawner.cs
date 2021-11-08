using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDir;
    private int rand;

    private RoomController roomController;

    private bool isRoomSpawned = false;

    private void Start()
    {
        //Get Room Controller
        roomController = GameObject.FindGameObjectWithTag("RoomController").GetComponent<RoomController>();

        //Start Room Spawning
        Invoke("SpawnRooms", 2f);
    }


    private void SpawnRooms()
    {
        //Check If Room is NOT Spawned
        if (isRoomSpawned == false)
        {

            //Spawn Rooms to Connecting Point with Correct Entry Direction!
            switch (openingDir)
            {

                //Spawn Bottom Entry
                case 1:
                    //Get Random Room
                    rand = Random.Range(0, roomController.bottomRooms.Length - 1);

                    //Instantiate Room
                    Instantiate(roomController.topRooms[rand], transform.position, roomController.topRooms[rand].transform.rotation);

                    break;
                //Spawn Top Entry
                case 2:
                    //Get Random Room
                    rand = Random.Range(0, roomController.topRooms.Length - 1);

                    //Instantiate Room
                    Instantiate(roomController.bottomRooms[rand], transform.position, roomController.bottomRooms[rand].transform.rotation);
                    break;
                //Spawn Left Entry
                case 3:
                    //Get Random Room
                    rand = Random.Range(0, roomController.leftRooms.Length - 1);

                    //Instantiate Room
                    Instantiate(roomController.rightRooms[rand], transform.position, roomController.rightRooms[rand].transform.rotation);
                    break;

                //Spawn Right Entry
                case 4:
                    //Get Random Room
                    rand = Random.Range(0, roomController.rightRooms.Length - 1);

                    //Instantiate Room
                    Instantiate(roomController.leftRooms[rand], transform.position, roomController.leftRooms[rand].transform.rotation);
                    break;
            }


            isRoomSpawned = true;
            roomController.currentRoomCount++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Prevent Rooms from Spawning on eachother
        if(collision.gameObject.tag == "SpawnPoint")
        {
            //Destroy Gameobject
            Destroy(gameObject);
        }
    }
}
