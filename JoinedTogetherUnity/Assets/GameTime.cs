using UnityEngine;
using TMPro;
using System.Collections;

public class GameTime : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    private float startTime;

    // Use this for initialization
    void Start()
    {
        // Time since application start
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if finished
        // CheckFinish();

        // holds current time
        float timeElapsed = Time.time - startTime;

        string minutes;
        if (((int) timeElapsed / 60) < 10)
        {
            minutes = "0" + ((int)timeElapsed / 60).ToString();
        }
        else
        {
            minutes = ((int)timeElapsed / 60).ToString();
        }

        string seconds;
        if (timeElapsed % 60 < 10)
        {
            seconds = "0" + (timeElapsed % 60).ToString("f2"); // only 2 decimals
        }
        else
        {
            seconds = (timeElapsed % 60).ToString("f2"); 
        }

        timerText.text = minutes + ":" + seconds;
    }
}
