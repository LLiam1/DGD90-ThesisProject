using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public RoomModule startRoom;

    public RoomModule endRoom;

    public List<RoomModule> currentPath = new List<RoomModule>();

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            currentPath = Pathfinder.Pathfind(startRoom, endRoom);
        }

        if (currentPath.Count > 0) { 
            if (Vector3.Distance(transform.position, currentPath[0].CurrentPos()) > 0.01)
            {
                float step = 5 * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, currentPath[0].CurrentPos(), step);
            } else
            {
                currentPath.RemoveAt(0);
            }
        }
    }

}
