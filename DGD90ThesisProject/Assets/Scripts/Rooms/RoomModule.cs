using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class RoomModule : MonoBehaviour
{
    //Room Controller
    private RoomController roomController;

    //This Rooms Neighbors 
    public List<RoomModule> theseNeighbors = new List<RoomModule>();

    //This Rooms Light
    public GameObject roomLight;

    //Switch Controlled Light
    public GameObject switchControlledLight;

    //Current Room Light Switch
    public GameObject roomLightSwitch;

    public bool isLightOn;

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

    public int X, Y;

    private void Awake()
    {
        //Is this tile accessable?
        isLightOn = false;

        //Get The Room Controller
        roomController = GameObject.FindGameObjectWithTag("RoomController").GetComponent<RoomController>();

        //Add Room to the  List
        roomController.rooms.Add(gameObject);

        //Reset Spawn Timer
        roomController.roomSpawnTimer = 0;

        isEntryRoom = false;
    }

    private void Update()
    {
        //Check Room Light Status
        CheckLight();
    }


    public void CheckLight()
    {
        if (roomLightSwitch.GetComponent<LightSwitch>().isActive)
        {
            isLightOn = true;
        }
        else
        {
            isLightOn = false;
        }
    }


    public List<RoomModule> Neighbors()
    {

        List<RoomModule> theseNeighbors = new List<RoomModule>();

        for (int i = 0; i <= 4; i++)
        {
            RoomModule potentialNeighbor = FindObjectOfType<RoomModule>();
        }

        return theseNeighbors;
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
        if (isGenerator)
        {
            //Spawn Generator Button
            Instantiate(roomController.generatorPrefab, transform.position, Quaternion.identity, par.transform);
        }
    }


    public Vector3 CurrentPos()
    {
        return transform.position;
    }

}
