using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class simply triggers and stops an audio clip to test the Equalizing Mechanic/Interaction.
public class AudioTrigger : MonoBehaviour
{
    public AudioSource triggerAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")triggerAudio.Play();
    }

    public void StopEqualizeSound()
    {
        triggerAudio.Stop();
        Debug.Log("Has Ecualized");
    }
}
