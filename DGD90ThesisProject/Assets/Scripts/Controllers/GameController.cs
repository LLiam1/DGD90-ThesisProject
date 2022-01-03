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

    //Keys required to reset Fuse!
    public const int MAX_KEYS_REQUIRED_RESET_FUSE = 3;

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

        if (!randomlyGenerateRooms)
        {
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
