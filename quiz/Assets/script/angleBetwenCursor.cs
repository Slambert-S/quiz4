using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleBetwenCursor : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pointPos = transform.position;

        // get the position of the mouse cursor in world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // calculate the vector that points from the point to the cursor
        Vector3 dir = mousePos - pointPos;

        // get the angle between the vector and the x-axis
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
    }
    public float getAngle()
    {

        Vector3 pointPos = transform.position;

        // get the position of the mouse cursor in world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // calculate the vector that points from the point to the cursor
        Vector3 dir = mousePos - pointPos;

        // get the angle between the vector and the x-axis
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return angle;

    }
}
