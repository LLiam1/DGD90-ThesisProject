using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CollisionModule : MonoBehaviour
{
    //Player Controller
    private PlayerController playerController;

    //Current Collision Object
    //public GameObject[] curretCollision;

    //List Because the Player can be in multiple Collisions at once
    public List<GameObject> currentCollisions = new List<GameObject>();

    private void Awake()
    {
        //Get the PController Component
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player Enters Staircase Trigger
        if (collision.gameObject.tag == "Staircase")
        {
            //Set Bool Trigger to True
            playerController.isPlayerInStaircase = true;
        }

        //Player Enters Switch Trigger
        if(collision.gameObject.tag == "LightSwitch")
        {
            //Set Bool Trigger to True
            playerController.isPlayerInLightswitch = true;
        }

        //Player Enters Fusebox Trigger
        if(collision.gameObject.tag == "Fusebox")
        {
            //Set Bool Trigger to True
            playerController.isPlayerInFusebox = true;
        }

        //Player enters Generator Trigger
        if(collision.gameObject.tag == "GeneratorButton")
        {
            playerController.isPlayerInGenerator = true;
        }

        if(collision.gameObject.tag == "Room")
        {
            playerController.currentRoom = collision.gameObject.GetComponent<RoomModule>();
        }

        //Set the current Collision object
        currentCollisions.Add(collision.gameObject);

        #region Old Light Trigger (Light Turns on When Entering)
        //Lighting
        //if(collision.gameObject.tag == "Light")
        //{
        //    //Enable Light
        //    collision.gameObject.GetComponent<Light2D>().intensity = 0.29f;
        //}

        #endregion
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        //Player Exits Staircase Trigger
        if (collision.gameObject.tag == "Staircase")
        {
            //Set Bool Trigger to False
            playerController.isPlayerInStaircase = false;
        }

        //Player Exits Switch Trigger
        if (collision.gameObject.tag == "LightSwitch")
        {
            //Set Bool Trigger to False
            playerController.isPlayerInLightswitch = false;
        }

        //Player Exits Fusebox Trigger
        if (collision.gameObject.tag == "Fusebox")
        {
            //Set bool Trigger to False
            playerController.isPlayerInFusebox = false;
        }

        if (collision.gameObject.tag == "GeneratorButton")
        {
            playerController.isPlayerInGenerator = false;
        }

        //Update Current Collision Object
        currentCollisions.Remove(collision.gameObject);


        #region Old Light Trigger (Light Turns off When Exitting)
        //Lighting
        //if (collision.gameObject.tag == "Light")
        //{
        //    //Disable Light
        //    collision.gameObject.GetComponent<Light2D>().intensity = 0;
        //}

        #endregion
    }

}
