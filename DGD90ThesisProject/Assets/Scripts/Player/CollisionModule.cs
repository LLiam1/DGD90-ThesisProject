using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        //Set the current Collision object
        curretCollision = collision.gameObject;
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
    }


}
