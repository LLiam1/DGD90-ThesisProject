using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Array of Light Switches
    public GameObject[] lightSwitches;

    //BackGround Gameobject
    public GameObject background;

    //Current Amount of Lights Active
    public int lightActiveCount = 0;

    //Maximium Lights Allowed Active at Once!
    public const int MAX_LIGHTS_ACITVE = 3;

    //Keys required to reset Fuse!
    public const int MAX_KEYS_REQUIRED_RESET_FUSE = 3; 

    //Bool Blown Fuse
    public bool isFuseBlown = false;

    private void Start()
    {
        //Get All Light Switches
        lightSwitches = GameObject.FindGameObjectsWithTag("LightSwitch");

        //Enable Background Object
        background.SetActive(true);

        //Disable all Light Switches on Start
        for (int i = 0; i <= lightSwitches.Length - 1; i++)
        {
            //TODO - Flicker Effect with all Lights Before all lights go out

            //Turn all Lights Off
            lightSwitches[i].GetComponent<LightSwitch>().isActive = false;
        } 
    }

    private void Update()
    {
        //Get the count of Active Lights
        lightActiveCount = GetLightCount();

        //Check if Fuse is Blown
        if (lightActiveCount > MAX_LIGHTS_ACITVE)
        {
            //Blown Fuse! Loop Through all Lights & Turn them Off
            for (int i = 0; i <= lightSwitches.Length - 1; i++)
            {
                //Turn all Lights Off
                lightSwitches[i].GetComponent<LightSwitch>().isActive = false;

                //Activate Blown Fuse
                isFuseBlown = true;
            }
        }
    }


    //Get Number of Active Lights
    private int GetLightCount()
    {
        //Light Counter
        int count = 0;

        //Loop through Array
        for(int i = 0; i<= lightSwitches.Length - 1; i++)
        { 
            //Check if Light is Active
            if (lightSwitches[i].GetComponent<LightSwitch>().isActive)
            {
                //Add to count
                count++;
            }
        }

        //Return Count
        return count;
    }
}
