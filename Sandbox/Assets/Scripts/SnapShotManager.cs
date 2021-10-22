using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SnapShotManager : MonoBehaviour
{
    public AudioMixerSnapshot day;
    public AudioMixerSnapshot night;
    public float transitionTime=2f;

    private void Start()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        night.TransitionTo(transitionTime);
    }
    private void OnTriggerExit(Collider other)
    {
        day.TransitionTo(transitionTime);
    }
}
