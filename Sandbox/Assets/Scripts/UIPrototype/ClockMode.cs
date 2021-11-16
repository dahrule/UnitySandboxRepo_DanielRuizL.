using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//This class is in charge of handling clock functionality (currently date & time only). The clock mode runs as soon as the game starts.
public class ClockMode : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText; //the display text for the time value.
    [SerializeField] TextMeshProUGUI dateText; //the display text for the date value.

    private bool is24hrFormat=true; //represents time format: 24 hr format (true) or 12 hr format (false).

    void Awake()
    {
        UpdateSystemDateTime();
    }
    private void OnEnable()
    {
        StartCoroutine(DisplayTimeRoutine());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    //Displays the time of day every minute on the dive computer's screen.vThe coroutine only stops when the script is disabled.
    private IEnumerator DisplayTimeRoutine()
    {
        while (true)
        {
            UpdateSystemDateTime();
            yield return new WaitForSeconds(60f);
        }
    }

    //Gets the date and time from the local system, and formats the time to either 24 or 12 hrs format.
    private void UpdateSystemDateTime()
    {
        //Update Time
        if (is24hrFormat) timeText.text=DateTime.Now.ToString("HH:mm"); //24 hrs format.
        else timeText.text = DateTime.Now.ToString("t"); //12 hrs format.

        //Update Date
        dateText.text = DateTime.Today.Date.ToString();

    }

    //Called with an OnClick() event.
    public void ToggleHourFormat()
    {
        is24hrFormat = !is24hrFormat;
        UpdateSystemDateTime();
    }

}
