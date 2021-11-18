using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiveScreen : Screen
{
    [SerializeField] TextMeshProUGUI depth_text;
    [SerializeField] TextMeshProUGUI time_text;
    [SerializeField] TextMeshProUGUI noDecTime_text;
    [SerializeField] TextMeshProUGUI diveTime_text;
    [SerializeField] TextMeshProUGUI temperature_text;
    [SerializeField] TextMeshProUGUI maxDepth_text;

    // Start is called before the first frame update
    void Start()
    {
        SetInitialState();
        DepthSensor.OnDepthChange += DisplayDepth;
        TimeDate.OnTimeUpdate += DisplayTime;
    }

    void DisplayDepth(float depth)
    {
        depth_text.text = depth.ToString("F1");
        
    }
    void DisplayTime(Dictionary<string, string> dateTime)
    {
        time_text.text = dateTime["time"];
    }

    protected override void SetInitialState()
    {
        depth_text.enabled = true;
        time_text.enabled = true;
        noDecTime_text.enabled = true;
        diveTime_text.enabled = true;
        temperature_text.enabled = false;
        maxDepth_text.enabled = false;
        
    }

    public override void HandleUpButtonPress()
    {
        diveTime_text.enabled = !diveTime_text.enabled;
        temperature_text.enabled = !temperature_text.enabled;
    }

    public override void HandleDownButtonPress()
    {
        time_text.enabled = !time_text.enabled;
        maxDepth_text.enabled = !maxDepth_text.enabled;
    }

}
