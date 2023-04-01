using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class previewTrajectory : MonoBehaviour
{
    // Public variables
    public float initialVelocity;
    public float launchAngle;
    public float initialHeight;
    public int numberPoint;

    // Private variables
    private float gravity = 9.81f; // Acceleration due to gravity
    private float timeOfFlight;
    private float horizontalDistance;
    private float maxHeight;
    private Vector2 initialPosition;
    private Vector2 currentPosition;
    private bool launched = false;
    private float launchTime;

    void Start()
    {
        // Convert the launch angle from degrees to radians
        float angleInRadians = launchAngle * Mathf.PI / 180;

        // Calculate the horizontal and vertical components of the initial velocity
        float initialVelocityX = initialVelocity * Mathf.Cos(angleInRadians);
        float initialVelocityY = initialVelocity * Mathf.Sin(angleInRadians);

        // Calculate the time of flight
        timeOfFlight = 2 * initialVelocityY / gravity;

        // Calculate the horizontal distance
        horizontalDistance = initialVelocityX * timeOfFlight;

        // Calculate the maximum height
        maxHeight = initialHeight + initialVelocityY * initialVelocityY / (2 * gravity);

        // Get the initial position of the game object
        initialPosition = transform.position;

        // Set the initial position of the projectile
        currentPosition = new Vector2(initialPosition.x, initialPosition.y + initialHeight);

        // Move the game object to the initial position
        transform.position = currentPosition;
        launchTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {


        launchAngle = this.GetComponent<angleBetwenCursor>().getAngle();
       // initialVelocity = GetComponent<playerController>().prefabGrenade.
        initialPosition = transform.position;
        Debug.Log(launchAngle);
        GameObject.Find("lineRender").GetComponent<lineControlelr>().SetUpLine(getPointPreview());
    }

    public Vector2[] getPointPreview()
    {

        Vector2[] listPoints = new Vector2[100];
        for(int i =0; i < numberPoint; i++)
        {
            int adjsutedI = i;

            if ( launchAngle < 90 && launchAngle >-90)
            {
                 adjsutedI = i;
            }
          
            else
            {
                adjsutedI = -i;
            }
            float timeSinceLaunch =  (timeOfFlight / numberPoint)* i;


            // Calculate the horizontal position
            float horizontalPosition = horizontalDistance * timeSinceLaunch / timeOfFlight;

            // Calculate the vertical position
            float verticalPosition = initialHeight + initialVelocity * Mathf.Sin(launchAngle * Mathf.PI / 180) * timeSinceLaunch - 0.5f * gravity * timeSinceLaunch * timeSinceLaunch;
            Vector2 newPoint = currentPosition;

            newPoint.x = initialPosition.x + horizontalPosition;
            newPoint.y = initialPosition.y + verticalPosition;
            listPoints[i] = newPoint;
            // Update the current position of the projectile
            currentPosition.x = initialPosition.x + horizontalPosition;
            currentPosition.y = initialPosition.y + verticalPosition;

        }
        return listPoints;
    }

}
