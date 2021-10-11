using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The class represents a timer.
public class TimeCounter : MonoBehaviour
{
    [SerializeField]
    float timeValue = 90.0f; //the total time in seconds the timer will run for.

    //Declares an event called OnTimeOver that will be called when the timer reaches zero.
    public delegate void TimeOver();
    public static event TimeOver OnTimeOver;


    // Start is called before the first frame update
    void Start()
    {
        UIManager.singleton.DisplayTime(timeValue); //calls the UIManager class to display the time counter on screen.
        StartCoroutine(Countdown()); //Starts a coroutine that will run every second.
    }

    //Couroutine that updates the time counter and displays it on the screen every second. When the time counter reaches zero an event is broadcasted indicating that time is over.
    IEnumerator Countdown()
    {
        while (timeValue>0) // the code inside the loop runs every second until the timecounter reaches zero.
        {
            yield return new WaitForSeconds(1); // this line indicates how often the code inside the while loop is called (1 second).
            timeValue -= 1; // reduces time counter value by one. Ensures whileloop ends.
            UIManager.singleton.DisplayTime(timeValue);
        }
        timeValue = 0;
        UIManager.singleton.DisplayTime(timeValue);

        if(OnTimeOver!=null) //Makes sure the event is not null before invoking it. Invoking an event with no suscribers causes an error.
        {
          OnTimeOver(); //Broadcasts the OnTimeOver event for registered classes to listen and respond.
        }
      
    }
    
}
