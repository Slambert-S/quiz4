using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable_wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyWall()
    {
        Destroy(this.gameObject);
    }

}
