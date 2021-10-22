using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;


public class ClimbInteractable : XRBaseInteractable
{
    
    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        Debug.Log("Enter");
        if (interactor is XRDirectInteractor)
        {
           Climber.climbingHand = interactor.GetComponent<ActionBasedController>();
            Debug.Log("OK2");
        }
    }

    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        Debug.Log("Exit");
        if (interactor is XRDirectInteractor)
        {
            if (Climber.climbingHand && Climber.climbingHand.name==interactor.name)
            {
                Climber.climbingHand = null;
            }
            
        }
    }
}
