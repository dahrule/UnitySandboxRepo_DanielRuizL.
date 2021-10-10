using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    bool overlaps = false;
    public bool Overlaps { get { return overlaps; }}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colllision occurred");
            overlaps = true;

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Colllision gone");
        overlaps = false;
    }
     
    

}
