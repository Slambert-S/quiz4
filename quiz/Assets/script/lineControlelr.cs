using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineControlelr : MonoBehaviour
{
    private LineRenderer lr;
    private Vector2[] points;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i =0; i< points.Length; i++)
        {
            lr.SetPosition(i, points[i]);
        }
    }

    public void SetUpLine(Vector2[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }
}
