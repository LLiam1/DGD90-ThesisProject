using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    //Light Object the switch Activates
    public GameObject rlight;

    //Light Controller
    private LightController lightController;

    //If Light is Active
    public bool isActive;

    //Check if Assigned
    public bool isAssigned;

    private void Start()
    {
        //Get the Light Controller Component
        lightController = GameObject.FindGameObjectWithTag("LightController").GetComponent<LightController>();
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
            //Check if Intensity Reach its Limit
            if (rlight.GetComponent<Light2D>().intensity < LightController.TARGET_LIGHT_INTENSITY)
            {
                //Increase Light Intensity
                rlight.GetComponent<Light2D>().intensity += lightController.lightIncreaseAmount * Time.deltaTime;
            }
        } else {
            //Check if Intensity Reach its Limit
            if (rlight.GetComponent<Light2D>().intensity > 0)
            {
                //Increase Light Intensity
                rlight.GetComponent<Light2D>().intensity -= lightController.lightDecreaseAmount * Time.deltaTime;
            }
        }
        
    }
}
