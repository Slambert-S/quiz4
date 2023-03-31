using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testColliderOverlaps : MonoBehaviour
{
    public Collider2D moveColider;
    public int ray = 1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkCollisions()
    {
        Vector2 position = this.transform.position;
        float distance = 0;

       int nbChild = GameObject.Find("wallParent").transform.childCount;
        int maxDestruction = 3;
        int wallDestroyed = 0;

        for (int i = 0; i < nbChild; i++)
        {
            GameObject childe = GameObject.Find("wallParent").transform.GetChild(i).gameObject;
            distance = Vector2.Distance(childe.transform.position, position);
            int inside = ray - 1;
            int outside = ray + 1;

            if (inside < distance || outside > distance)
            {

                Debug.Log(childe.name);
                childe.GetComponent<destructable_wall>().destroyWall();
                wallDestroyed++;
            }

            if(wallDestroyed == maxDestruction)
            {
                i = nbChild;
            }

            

            //Debug.Log(childe.name);
        }
    }

   
}
