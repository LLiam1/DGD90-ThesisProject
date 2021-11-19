using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseController : MonoBehaviour
{
    //Staircase Destination
    public Vector3 destination;

    //GameObject Destination
    public GameObject scDestination;

    //Staircase goes Up
    public bool isUpStaircase;

    //Staircase goes down
    public bool isDownStaircase;

    private void Start()
    {
        if (isUpStaircase)
        {
            //Up Staircase
            destination = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        } else if(isDownStaircase)
        {
            //Down Staircase
            destination = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
        } else
        {
            //This is not a staircase!
            return;
        }

        #region Old Code
        //TODO:  Calculate Destination based on Staircase Direction

        //if (isUpStaircase)
        //{
        //    //Raycast Up
        //    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 10f);


        //    if(hit.collider.gameObject.tag == "Staircase")
        //    {
        //        Debug.Log(hit.collider.gameObject.name);


        //        //Staircase Found!
        //        scDestination = hit.collider.gameObject;
        //        destination = scDestination.transform.position;
        //    }

        //} else if (isDownStaircase)
        //{

        //} else
        //{
        //    //Not a Staircase
        //    return;
        //}

        #endregion
    }

}
