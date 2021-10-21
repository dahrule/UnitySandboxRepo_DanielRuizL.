using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script listens to Pressure Change events. When the event is listened it will sometimes play a disturbing sound on the AudioSource attached to the avatar. By pinching close to the nose, the sound will disappear. Sometimes more than one pinch is be required.
public class Equalize : MonoBehaviour
{
    [SerializeField]
    AudioClip pressureOnEars;


    // This function runs when the Interactable containing this script is selected by an Interactor working on the Pinch Layer Mask.
    public void StopEqualizeSound()
    {

        Debug.Log("hAS EQUALIZE");
    }


}
