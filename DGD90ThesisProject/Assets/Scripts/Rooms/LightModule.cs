using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightModule : MonoBehaviour
{
    //Components
    private RoomController roomController;

    //Bool to Track Light Status
    public bool isLightOn;

    private void Awake()
    {
        //Get RoomController
        roomController = GetComponent<RoomController>();
    }

    private void Update()
    {
        if (isLightOn)
        {
            //Room Light is On!
            //TODO Turn Room Visibility On
        } else
        {
            //Room Light is Off.
            //TODO Turn visibility Off
        }
    }

}
