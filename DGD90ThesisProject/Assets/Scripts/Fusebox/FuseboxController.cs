using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseboxController : MonoBehaviour
{
    public GameController gameController;


    public void FixFusebox()
    {
        //Fuse is no longer Blown
        gameController.isFuseBlown = false;

        //TODO: Some effect to show Electricity has been restored
        Debug.Log("Fuse Fixed!");
    }

}
