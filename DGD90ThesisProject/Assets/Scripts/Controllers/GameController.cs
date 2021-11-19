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

    public LightController lightController;

    //Keys required to reset Fuse!
    public const int MAX_KEYS_REQUIRED_RESET_FUSE = 3;

    //Bool Blown Fuse
    public bool isFuseBlown = false;

    private void Start()
    {
        //Enable Background Object
        background.SetActive(true);

        lightController = GameObject.FindGameObjectWithTag("LightController").GetComponent<LightController>();
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
