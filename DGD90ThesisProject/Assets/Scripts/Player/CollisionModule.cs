using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CollisionModule : MonoBehaviour
{
    private PlayerController playerController;

    public GameObject curretCollision;
    

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
            playerController.isPlayerInStaircase = true;
        }

        //Player Enters Switch Trigger
        if(collision.gameObject.tag == "LightSwitch")
        {
            playerController.isPlayerInLightswitch = true;
        }

        //Set the current Collision object
        curretCollision = collision.gameObject;

        //Lighting
        //if(collision.gameObject.tag == "Light")
        //{
        //    //Enable Light
        //    collision.gameObject.GetComponent<Light2D>().intensity = 0.29f;
        //}

        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Player Exits Staircase Trigger
        if (collision.gameObject.tag == "Staircase")
        {
            playerController.isPlayerInStaircase = false;
        }

        //Update Current Collision Object
        curretCollision = null;

        //Lighting
        //if (collision.gameObject.tag == "Light")
        //{
        //    //Disable Light
        //    collision.gameObject.GetComponent<Light2D>().intensity = 0;
        //}
    }

}
