using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject[] entryRooms;

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    //Max number of rooms
    public int maxRooms = 10;

    //Current Room Count (Excludes entry room)
    public int currentRoomCount = 0;
    

    public void Awake()
    {
        //Get Random Entry Room
        int rand = Random.Range(0, entryRooms.Length - 1);

        //Instantiate Entry Room
        Instantiate(entryRooms[rand], Vector3.zero, entryRooms[rand].transform.rotation);
    }
}
