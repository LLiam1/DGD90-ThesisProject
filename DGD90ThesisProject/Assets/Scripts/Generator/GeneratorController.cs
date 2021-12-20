using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    //Generator Status
    public bool isGeneratorActive = false;

    //Generator Popup Window
    public GameObject popupPrefab;

    public void DisplayPopupWindow()
    {
        //Make Sure No other popup is displayed
        //Destroy(GameObject.FindGameObjectWithTag("PopupWindow"));

        //Display
        Instantiate(popupPrefab, transform.position, Quaternion.identity, transform);

    }
}
