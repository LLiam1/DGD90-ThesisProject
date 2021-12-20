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

    //Room is Generator Room
    public bool isGenertator = false;

    private void Start()
    {
        //Get The Room Controller
        roomController = GameObject.FindGameObjectWithTag("RoomController").GetComponent<RoomController>();

        //Add Room to the  List
        roomController.rooms.Add(gameObject);

        //Reset Spawn Timer
        roomController.roomSpawnTimer = 0;

        isEntryRoom = false;
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

    public void SpawnElevator(GameObject par)
    {
        //Verifiy if this Elevator Room
        if (isElevatorRoom)
        {
            //Spawn Elevator
            Instantiate(roomController.elevatorPrefab, transform.position, Quaternion.identity, par.transform);
        }
    }

    public void SpawnGeneratorButton(GameObject par)
    {
        //Verifiy if this is a Generator Room
        if(isGenertator)
        {
            //Spawn Generator Button
            Instantiate(roomController.generatorPrefab, transform.position, Quaternion.identity, par.transform);
        }
    }
}
