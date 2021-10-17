﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{
    //PlayerController
    private PlayerController playerController;

    private void Awake()
    {
        //Get the Player Controller Component
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        //Check If Key (E) is Pressed AND if Player is in a staircase Trigger.
        if (Input.GetKeyDown(playerController.staircaseIntKey) && playerController.isPlayerInStaircase)
        {
            for(int i = 0; i <= playerController.collisionModule.currentCollisions.Count -1; i++)
            {
                //Check if Gameobject is a Staircase
                if (playerController.collisionModule.currentCollisions[i].tag == "Staircase")
                {

                    //This will move the player & Get the destination of the staircase
                    playerController.movementModule.SCMovement(playerController
                        .collisionModule.currentCollisions[i].GetComponent<StaircaseController>().destination);

                    //Break out of Loops (Found what we needed)
                    break;
                }
            }
        }

        //Player is Interacting with Light Switch 
        if(Input.GetKeyDown(playerController.lightIntKey) && playerController.isPlayerInLightswitch && playerController.gameController.isFuseBlown == false)
        {
            for (int i = 0; i <= playerController.collisionModule.currentCollisions.Count - 1; i++)
            {
                //Check if Gameobject is a LighSwitch
                if (playerController.collisionModule.currentCollisions[i].tag == "LightSwitch")
                {

                    //Set bool to opposite of what it currently is
                    playerController.collisionModule.currentCollisions[i].GetComponent<LightSwitch>().isActive
                = !playerController.collisionModule.currentCollisions[i].GetComponent<LightSwitch>().isActive;

                    //Break out of Loops (Found what we needed)
                    break;
                }
            }
        }

        //Player is Interacting with Fusebox
        if(Input.GetKeyDown(playerController.fixFuseKey) && playerController.isPlayerInFusebox)
        {
            if(playerController.fuseBoxKeysCount >= GameController.MAX_KEYS_REQUIRED_RESET_FUSE)
            {
                //Collected all Required Keys
                for (int i = 0; i <= playerController.collisionModule.currentCollisions.Count - 1; i++)
                {
                    //Check if Gameobject is a LighSwitch
                    if (playerController.collisionModule.currentCollisions[i].tag == "Fusebox")
                    {
                        //Get Fusebox Controller and Call FixFuse Function
                        playerController.collisionModule.currentCollisions[i].gameObject.GetComponent<FuseboxController>().FixFusebox();

                        //Break out of Loops (Found what we needed)
                        break;
                    }
                }
            } else
            {
                //Does not have enough Keys to Unlock Fusebox.
                Debug.Log("Collect the Keys to Unlock the Fusebox!");
            }
            
        }
    }
}
