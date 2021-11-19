using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{

    // Check for Gameobject Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ignore If it is a Staircase
        //if (collision.gameObject.tag == "Staircase" || collision.gameObject.tag == "Light" ||
        //    collision.gameObject.tag == "LighSwitch" || collision.gameObject.tag == "Player")
        //{
        //    return;
        //}

        //Destroy GameObject

        if (collision.gameObject.tag == "SpawnPoint" || collision.gameObject.tag == "ClosedRooms")
        {
            Destroy(collision.gameObject);
        }
    }
}
