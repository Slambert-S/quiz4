using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWallCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    public bool touchingWall(float ray)
    {
        Vector2 position = this.transform.position;
        float distance = 0;
       

        int nbChild = GameObject.Find("wallParent").transform.childCount;
      

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
               

                return true;
            }

           



            //Debug.Log(childe.name);
        }
        return false;
    }
}
