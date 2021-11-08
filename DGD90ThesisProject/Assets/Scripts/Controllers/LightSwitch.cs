using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    //Light Object the switch Activates
    public GameObject rlight;

    //GameController
    private GameController gameController;

    //If Light is Active
    public bool isActive;

    private void Start()
    {
        //Get the Game Controller Component
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        //Check if GameObject is Null
        if(rlight == null)
        { 
            //Return if Gameobject is null
            return;
        }

        //Check If Light is Active
        if (isActive)
        {
            //Set Intensity! Light ON!
            rlight.GetComponent<Light2D>().intensity = GameController.TARGET_LIGHT_INTENSITY;
            //StartCoroutine(gameController.SlowlyLightRoom(rlight.GetComponent<Light2D>()));

        } else {
            //Set Intensity! Light OFF!
            rlight.GetComponent<Light2D>().intensity = 0f;
        }
        
    }
}
