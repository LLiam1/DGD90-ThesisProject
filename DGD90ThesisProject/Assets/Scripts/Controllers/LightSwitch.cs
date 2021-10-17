using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{

    //Light Object the switch Activates
    public GameObject rlight;

    //If Light is Active
    public bool isActive;

    private void Update()
    {
        //Return if Gameobject is null
        if(rlight == null)
        {
            return;
        }

        //Check If Light is Active
        if (isActive)
        {
            //Set Intensity! Light ON!
            rlight.GetComponent<Light2D>().intensity = 0.29f;
        } else {
            //Set Intensity! Light OFF!
            rlight.GetComponent<Light2D>().intensity = 0f;
        }
        
    }
}
