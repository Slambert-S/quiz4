using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyTimer : MonoBehaviour
{


    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TMP_Text time;
    public GameObject ui;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = false;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GetComponent<enemyVariable>().canShoot = true;
                
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
      
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        time.text = seconds.ToString();
        

    }
    public void ResetTimer()
    {
        timerIsRunning = false;
        timeRemaining = 10;
    }

    public void startTimer()
    {
        timerIsRunning = true;
    }
}
