using System.Collections;
using UnityEngine;
using System;

//Depth sensing functionality. This class is referenced by other objects requiring an updated depth value (eg. dive computer for displaying or charater for buoyancy calculation.
public class DepthSensor : MonoBehaviour
{
    [Tooltip("Reference point to measure depth (m).")]
    [SerializeField] Transform surface; //surface reference point.

    [Tooltip("Time interval in seconds in which depth is measured relative to the surface")]
    [SerializeField] float sensingTime = 1f; //the time interval in seconds in which depth is measured relative to the surface.

    private IEnumerator depthSense; //variable to store the coroutine in charge of measuring depth in the -sensingTime- interval.

    private float depth; //stores the updated depth value.
    private float maxDepth; //stores the maximum depth value reached until the last measured time. 
    public float Depth { get { return depth; } }

    public static event Action<float> OnDepthChange; //event that notifies when depth has significantly changed and returns the updated depth value.


    //Initializes the coroutine variable when the script instance is being loaded. Note that the coroutine runs later when the object is enabled.
    private void Awake()
    {
        depthSense = DepthSenseRoutine(sensingTime);

        //TO DO. Handle if no surface object is given.
    }

    //When the object containing this script becomes enabled and active, the coroutine -depth sense- starts runnnig.
    private void OnEnable()
    {
        StartCoroutine(depthSense);
    }
    private void OnDisable()
    {
        StopCoroutine(depthSense);
    }

    //Coroutine that updates the depth value. Every -sensingTime- seconds it calculates the distance from this gameobject to the surface reference point.
    private IEnumerator DepthSenseRoutine(float interval)
    {
        float temp_previousDepth=depth; //temporal depth value to compar with upadted value and determine if ith has changed.
        while (true)
        {
            depth = Mathf.Abs(this.transform.position.y-surface.position.y);
            

            // TO CHECK: Probably is not neccesary to do the following check condition....
            //OnDepthChange is only invoked if depth has significantly changed (ie. first decimal after point changes). This is to reduce the total number of event calls.
            depth = RoundtoTens(depth);
            if (temp_previousDepth != depth)
            {
                OnDepthChange?.Invoke(depth);
                
            }

            yield return new WaitForSeconds(interval);
        }
    }

    //Rounds a float number to the tens.
    private float RoundtoTens(float number)
    {
        return float.Parse(number.ToString("F1"));
    }
      
}
