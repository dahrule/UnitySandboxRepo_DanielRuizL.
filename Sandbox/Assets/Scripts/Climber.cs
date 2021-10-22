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
        if (climbingHand)
        {
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
        characterController.Move(transform.rotation * -currentVelocity * Time.deltaTime);

        previousPos = climbingHand.positionAction.action.ReadValue<Vector3>();
    }
}

