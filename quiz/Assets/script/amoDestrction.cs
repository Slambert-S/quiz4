using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amoDestrction : MonoBehaviour
{
    public float amoRad;
    public int maxDestruction =0;
    private int currentDestruction = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collisionDetected(string shooterName)
    {
        Debug.Log("in collisionDetected");
        Vector2 position = this.transform.position;
        float distance = 0;
        GameObject parentOfWall = GameObject.Find("wallParent");
        GameObject parentOfsoldier = GameObject.Find("wormsList");
        int nbChildWall = parentOfWall.transform.childCount;
        int nbChildWorms = parentOfsoldier.transform.childCount;

        for (int i = 0; i < nbChildWorms; i++)
        {
            GameObject childe = parentOfsoldier.transform.GetChild(i).gameObject;
            distance = Vector2.Distance(childe.transform.position, position);

            //Change later to use radius of the object
            float inside = amoRad + 1;
            float outside = amoRad - 1;

            if (inside > distance)
            {
                if(childe.name != shooterName)
                {
                    Destroy(childe);
                }
              //  Debug.Log(childe.name);
                //childe.GetComponent<destructable_wall>().destroyWall();
               // wallDestroyed++;
            }

            /*if (wallDestroyed == maxDestruction)
            {
                i = nbChild;
            }*/



            //Debug.Log(childe.name);
        }

        for (int j = 0; j < nbChildWall; j++)
        {
            GameObject childe = parentOfWall.transform.GetChild(j).gameObject;
            distance = Vector2.Distance(childe.transform.position, position);

            //Change later to use radius of the object
            float inside = amoRad + 1;
            float outside = amoRad - 1;

            if (inside > distance)
            {

                //Debug.Log(childe.name);
                childe.GetComponent<destructable_wall>().destroyWall();
                currentDestruction++;
            }

            if (currentDestruction == maxDestruction)
            {
                j = nbChildWall;
            }



            //Debug.Log(childe.name);
        }





    }
}
