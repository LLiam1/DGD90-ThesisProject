using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    public GameObject rlight;

    public bool isActive;

    private void Update()
    {
        if(rlight == null)
        {
            return;
        }

        if (isActive)
        {
            rlight.GetComponent<Light2D>().intensity = 0.29f;
        }
        else
        {
            rlight.GetComponent<Light2D>().intensity = 0f;
        }
        
    }
}
