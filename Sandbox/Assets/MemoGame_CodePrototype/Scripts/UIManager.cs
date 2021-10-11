using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class in charge of displaying the score and time count down into the screen.
public class UIManager : MonoBehaviour
{
    int score = 0;
    public int Score { get { return score; } }

    public Text scoreText;
    public Text TimeText;

    public static UIManager singleton;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        TimeText.text ="0:0"; 
    }

   
    public void AddPoints(int points)
    {
        score +=1;
        scoreText.text = score.ToString() + " POINTS";
    }

    //Receives total time in seconds and splits it into minutes and seconds.
    public void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        TimeText.text = minutes + ":" + seconds;
        Debug.Log(TimeText.text);
    }
}
