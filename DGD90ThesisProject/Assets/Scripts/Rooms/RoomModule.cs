﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomModule : MonoBehaviour
{
    //Room Controller
    private RoomController roomController;


//Locating its position relative to others
    public int X; 
    public int Y;

    public bool lightOff;

    //Room is Entry Room
    public bool isEntryRoom = false;

    //Room is Trap Room
    public bool isTrapRoom = false;

    //Room is Fuse Room
    public bool isFuseRoom = false;

    //Room is Elevator Room
    public bool isElevatorRoom = false;

    //Room is Generator Room
    public bool isGenerator = false;

    private void Awake()
    {
        //Is this tile accessable?
        lightOff = true;
        CanEnter();

        //Get The Room Controller
        roomController = GameObject.FindGameObjectWithTag("RoomController").GetComponent<RoomController>();

        //Add Room to the  List
        roomController.rooms.Add(gameObject);

        //Reset Spawn Timer
        roomController.roomSpawnTimer = 0;

        isEntryRoom = false;

    }

    //Changing the State of the Room Based on the local light
    public bool CanEnter(){
        if(lightOff == true) return true;

        else return false;
    }

    public List<RoomModule> Neighbors(){
        List<RoomModule> theseNeighbors = new List<RoomModule>();
        for(int i = 0; i <= 4; i++){
        RoomModule[i] potentialNeighbor = FindObjectOfType<RoomModule>();
        }
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
        if(isGenerator)
        {
            //Spawn Generator Button
            Instantiate(roomController.generatorPrefab, transform.position, Quaternion.identity, par.transform);
        }
    }
}
