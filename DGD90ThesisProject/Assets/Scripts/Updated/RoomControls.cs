using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class RoomControls : MonoBehaviour
{
    //Current Room Light
    public Light2D currentRoomLight;

    //Light controlled by Switch
    public Light2D switchLight;

    public void setSwitchLight(Light2D _switchLight)
    {
        switchLight = _switchLight;
    }
}
