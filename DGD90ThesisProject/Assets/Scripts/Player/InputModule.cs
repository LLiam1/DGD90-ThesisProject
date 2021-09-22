﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{
    private PlayerController playerController;


    private void Awake()
    {
        //Get the PController Component
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        //Check If Key (E) is Pressed AND if Player is in a staircase Trigger.
        if (Input.GetKeyDown(KeyCode.E) && playerController.isPlayerInStaircase)
        {
            Debug.Log("Key Pressed!");

            //This will move the player & Get the destination of the staircase
            playerController.movementModule.SCMovement(playerController
                .collisionModule.curretCollision.GetComponent<StaircaseController>().destination);
        }
    }
}
