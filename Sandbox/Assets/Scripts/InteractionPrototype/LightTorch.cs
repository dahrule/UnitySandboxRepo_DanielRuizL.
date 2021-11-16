using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Describes the behaviour for the lighttorch.

[RequireComponent(typeof(AudioSource))]
public class LightTorch : MonoBehaviour
{
    [SerializeField]
    AudioClip switchSound;
    [SerializeField]
    AudioSource audiosource;

    Light lightComponent;

    // Start is called before the first frame update
    void Start()
    {
        //Prepare sound effect
        if(audiosource==null)audiosource=GetComponent<AudioSource>(); //If an audio source was not assigned, find it in this gameobject.
        audiosource.clip = switchSound;
        audiosource.playOnAwake = false;

        //Set default torchlight values.
        lightComponent = GetComponentInChildren<Light>();
        lightComponent.enabled = false;
    }

    //Toggles light On or Off.
    public void ToggleLight()
    {
        lightComponent.enabled = !lightComponent.enabled; //Enables/disables Light Component.
        audiosource.PlayOneShot(switchSound); //Play audio effect.
        
    }
}
