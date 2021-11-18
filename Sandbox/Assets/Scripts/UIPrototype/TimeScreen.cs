using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScreen : Screen
{
    public TextMeshProUGUI time_text;
    public TextMeshProUGUI date_text;

    // Start is called before the first frame update
    void Start()
    {
        TimeDate.OnTimeUpdate += DisplayDateTime;
    }
    void DisplayDateTime(Dictionary<string, string> dateTime)
    {
        time_text.text = dateTime["time"];
        date_text.text = dateTime["date"];
    }

    public override void HandleDownButtonPress()
    {
        TimeDate.ToggleHourFormat();
    }

}
