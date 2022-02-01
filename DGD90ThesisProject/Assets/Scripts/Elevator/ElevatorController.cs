using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    //Room Controller
    public RoomController roomController;

    //Generator Buttons
    public GameObject[] generatorButtons;

    //Time Limit Before Generator Resets (If Timer Exceeds Generators will turn off)
    public const float MAX_ELEVATOR_ACTIVE_TIME = 30f;

    //Elevator Timer
    public float elevatorTimer = 0;

    //Elevator Active Status
    public bool isElevatorActive = false;

    private void Start()
    {
        //Get GeneratorButtons
        generatorButtons = GameObject.FindGameObjectsWithTag("GeneratorButton");

        //Get RoomController
        roomController = GameObject.FindGameObjectWithTag("RoomController").GetComponent<RoomController>();
    }

    public void Update()
    {
        //Update Elevator Status
        isElevatorActive = ElevatorActiveStatus();

        //Check if Elevator is Active
        if (isElevatorActive)
        {
            //Check Timer
            if (elevatorTimer >= MAX_ELEVATOR_ACTIVE_TIME)
            {
                //Elevator No longer Active (Time ran out)
                isElevatorActive = false;

                //Turn off each Generator Buttons 
                for (int i = 0; i <= generatorButtons.Length - 1; i++)
                {
                    //TODO: Deactivate each Generator Buttons
                    generatorButtons[i].GetComponent<GeneratorController>().isGeneratorActive = false;
                }

                elevatorTimer = 0;
            }
            else
            {
                //Add Time to Timer
                elevatorTimer = elevatorTimer + 1 * Time.deltaTime;
            }
        }

    }

    private bool ElevatorActiveStatus()
    {
        //Count of Active Generators
        int count = 0;

        for (int i = 0; i <= generatorButtons.Length - 1; i++)
        {
            //Check if ALL generator Buttons Active
            if (generatorButtons[i].GetComponent<GeneratorController>().isGeneratorActive == true)
            {
                //Increase Active Count
                count++;
            }
        }

        //Check the C
        if (count == roomController.numGenButtons)
        {
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && ElevatorActiveStatus())
        {
            Debug.Log("Player Won!");
        }
    }
}
