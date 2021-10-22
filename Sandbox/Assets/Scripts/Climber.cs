using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//Class that allows the player to climb objects with component of type ClimbInteractable.
public class Climber : MonoBehaviour
{
    private CharacterController characterController;
    public static ActionBasedController climbingHand; 
    private ContinuosMovement continuousMovement;

    private ActionBasedController previousHand;
    private Vector3 previousPos;
    private Vector3 currentVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ContinuosMovement>();

        Debug.Log(previousPos);
    }

    void FixedUpdate()
    {
        if (climbingHand) //if a climbing hand has been assigned  by a ClimbInteractable instance.
        {
            //Gets the velocity of the hand, comparing the displacement between previous hand position and current hand position in the Fixedupdate loop. The velocity is then applied as a vector with opposite direction. The direction of movement is opposite to the velocity direction of the hand.
            if (previousHand == null)
            {
                previousHand = climbingHand;
                previousPos = climbingHand.positionAction.action.ReadValue<Vector3>();
            }
            if (climbingHand.name != previousHand.name)
            {
                previousHand = climbingHand;
                previousPos = climbingHand.positionAction.action.ReadValue<Vector3>();
                Debug.Log("DIFFERENT HAND NOW");
            }
            continuousMovement.enabled = false;
            Climb();
        }
        else
        {
            continuousMovement.enabled = true;
        }
    }

    private void Climb()
    {
        currentVelocity = (climbingHand.positionAction.action.ReadValue<Vector3>() - previousPos) / Time.deltaTime;
        characterController.Move(transform.rotation * -currentVelocity * Time.deltaTime); // moves using the character controller component. uses the change in velocity between hand

        previousPos = climbingHand.positionAction.action.ReadValue<Vector3>();
    }
}

