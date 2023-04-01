using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBulledtArc : MonoBehaviour
{
    // Public variables
    public float initialVelocity;
    public float launchAngle;
    public float initialHeight;
    public bool readyToLaunch = false;

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
  
    void FixedUpdate()
    {

        if (!readyToLaunch)
        {
            return;
        }
        // If the projectile has not been launched, launch it
        if (!launched)
        {
            launched = true;
            return;
        }

        // Calculate the time since launch

        float timeSinceLaunch = Time.time - launchTime;
      

        // Calculate the horizontal position
        float horizontalPosition = horizontalDistance * timeSinceLaunch / timeOfFlight;

        // Calculate the vertical position
        float verticalPosition = initialHeight + initialVelocity * Mathf.Sin(launchAngle * Mathf.PI / 180) * timeSinceLaunch - 0.5f * gravity * timeSinceLaunch * timeSinceLaunch;

        // Update the current position of the projectile
        currentPosition.x = initialPosition.x + horizontalPosition;
        currentPosition.y = initialPosition.y + verticalPosition;

        // Move the game object to the current position
        transform.position = currentPosition;


        if (timeSinceLaunch < 0.1){
            return;
        }
        Debug.Log(timeSinceLaunch);
            bool colision = checkColisions();
        if (colision)
        {
            GetComponent<amoDestrction>().collisionDetected(gameObject.name);
            Destroy(this.gameObject);
        }
    }

    public bool checkColisions()
    {
        Vector2 position = this.transform.position;
        float distance = 0;
        int ray = 1;

        int nbChild = GameObject.Find("wallParent").transform.childCount;
        int maxDestruction = 3;
        int wallDestroyed = 0;

        for (int i = 0; i < nbChild; i++)
        {
            GameObject childe = GameObject.Find("wallParent").transform.GetChild(i).gameObject;
            distance = Vector2.Distance(childe.transform.position, position);
            float inside = ray + 0.5f;
            //int inside = ray + 1;
            //  Debug.Log(distance);
            // Debug.Log(inside);
            if (inside > distance)
            {

                //Debug.Log(childe.name);
                i = nbChild;

                return true;
            }

            if (wallDestroyed == maxDestruction)
            {
                i = nbChild;
            }



            //Debug.Log(childe.name);
        }
        return false;
    }
}
