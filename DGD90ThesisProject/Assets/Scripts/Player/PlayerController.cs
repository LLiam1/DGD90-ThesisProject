using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Modules
    public MovementModule movementModule;
    public CollisionModule collisionModule;
    public InputModule inputModule; 

    public Rigidbody2D rb;

    public float moveSpeed;

    public bool isPlayerInStaircase;
    public bool isPlayerInLightswitch;

    private void Awake()
    {
        //Assign RigidBody Component
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Call Player Movement
        movementModule.Movement(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0));
    }
}
