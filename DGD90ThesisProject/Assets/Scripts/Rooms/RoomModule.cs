using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomModule : MonoBehaviour
{
    //Room Controller
    private RoomController roomController;

    //Room is Entry Room
    public bool isEntryRoom = false;

    //Room is Trap Room
    public bool isTrapRoom = false;

    //Room is Fuse Room
    public bool isFuseRoom = false;

    //Room is Elevator Room
    public bool isElevatorRoom = false;

    private void Start()
    {
        //Get The Room Controller
        roomController = GameObject.FindGameObjectWithTag("RoomController").GetComponent<RoomController>();

        //Add Room to the  List
        roomController.rooms.Add(gameObject);

        //Reset Spawn Timer
        roomController.roomSpawnTimer = 0;
    }

    public void SpawnFusebox(GameObject par)
    {
        //Verifiy This is Fuse Room
        if (isFuseRoom)
        {
            //Spawn Fusebox
            Instantiate(roomController.fuseboxPrefab, transform.position, Quaternion.identity, par.transform);
        }
    }

    public void SpawnElevator()
    {

    }
}
