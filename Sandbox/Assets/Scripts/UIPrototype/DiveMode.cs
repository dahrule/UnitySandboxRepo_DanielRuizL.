using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This class is in charge of handling dive functionalities (depth sensing, No-deco time, and divetime). The script is enabled once the diver enters a surface trigger volume.
public class DiveMode : MonoBehaviour
{
    //Depth sensing functionality
    [Tooltip("Transform that serves as the reference point to measure depth (m).")]
    [SerializeField] Transform surface; //surface reference point

    [Tooltip("How often in seconds is the computer sensing and displaying the depth")]
    [SerializeField] float sensingTime=1f; //the time interval in seconds at which the computer reads the depth.

    [SerializeField] TextMeshProUGUI depthText; //the display text for the depth value.

    private IEnumerator depthSense;
    private float depth;
    public float Depth { get { return depth; } }

    //Dive time functionality
    [SerializeField] TextMeshProUGUI noDecTimeText; //the display text for the no-deco time value.



    //No-deco time functionality
    [SerializeField] TextMeshProUGUI diveTimeText; //the display text for the dive time value.

    private IEnumerator diveTime;

    private void Awake()
    {
        depthSense = DepthSenseRoutine(sensingTime);
    }

    private void OnEnable()
    {
        
        StartCoroutine(depthSense);
        StartCoroutine(depthSense);
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }


    //Updates and Displays the depth relative to the surface at a time interval.
    private IEnumerator DepthSenseRoutine(float interval)
    {
        while(true)
        {
            depth = Vector3.Distance(this.transform.position, surface.position);
            depthText.text = depth.ToString();
            yield return new WaitForSeconds(interval);
        }   
    }

    private IEnumerator DiveTimeRoutine(float interval)
    {
        while (true)
        {
            depth = Vector3.Distance(this.transform.position, surface.position);
            depthText.text = depth.ToString();
            yield return new WaitForSeconds(interval);
        }
    }


}
