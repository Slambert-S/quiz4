using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugPointssignment : MonoBehaviour
{
    [SerializeField] private Vector2[] points;
    [SerializeField] private lineControlelr line;
    // Start is called before the first frame update
    void Start()
    {
        line.SetUpLine(points);
    }

  
}
