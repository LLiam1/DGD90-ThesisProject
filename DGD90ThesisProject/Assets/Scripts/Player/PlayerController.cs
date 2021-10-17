using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Modules
    public MovementModule movementModule;
    public CollisionModule collisionModule;
    public InputModule inputModule;

    //Game Controller
    public GameController gameController;

    //RigidBody
    public Rigidbody2D rb;

    //Speed
    public float moveSpeed;

    //Key Controlled
    public KeyCode staircaseIntKey = KeyCode.E;
    public KeyCode lightIntKey = KeyCode.Q;
    public KeyCode fixFuseKey = KeyCode.Z;

    //Trigger Bools
    public bool isPlayerInStaircase;
    public bool isPlayerInLightswitch;
    public bool isPlayerInFusebox;

    //Items
    public int fuseBoxKeysCount = 0;

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
