using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameController : MonoBehaviour
{ 
    //BackGround Gameobject
    public GameObject background;

    //Player Prefab
    public GameObject playerPrefab;

    //Light Controller
    public  LightController lightController;

    //Room Controller
    private RoomController roomController;

    //Bool Blown Fuse
    public bool isFuseBlown = false;

    //Bool Randomly Generat Rooms (ON/OFF)
    public bool randomlyGenerateRooms = true;

    private void Start()
    {
        //Enable Background Object
        background.SetActive(true);

        //Get Light Controller
        lightController = GameObject.FindGameObjectWithTag("LightController").GetComponent<LightController>();

        //Get Room Controller
        roomController = GameObject.FindGameObjectWithTag("RoomController").GetComponent<RoomController>();

        //Randomly Generate Rooms
        if (!randomlyGenerateRooms)
        {
            //Setup Rooms
            roomController.SetupRooms();
        }

        roomController.gameController = this;
    }

    //Play Spawn Function
    public void SpawnPlayer(Vector3 pos)
    {
        //Resposition Player
        pos.y = -3;

        //Instantiate Player
        Instantiate(playerPrefab, pos, Quaternion.identity);
    }
}
