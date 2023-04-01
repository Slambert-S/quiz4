using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTimer : MonoBehaviour
{


    public float timeRemaining = 5;
    public bool timerIsRunning = false;
   
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
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
        Debug.Log(seconds);
        
    }
    public void ResetTimer()
    {
        timerIsRunning = false;
        timeRemaining = 3;
    }

    public void startTimer()
    {
        timerIsRunning = true;
    }
}
