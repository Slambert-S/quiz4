using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugPress : MonoBehaviour
{
    public int speed = 5;
    Vector2 direction;
    public bool checkMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 direction = transform.right;


    }
   
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K) == true)
        {
            Debug.Log("key pressed");
            //GetComponentInChildren<testColliderOverlaps>().checkCollisions();
            checkMoving = true;
        }

        if (checkMoving == true)
        {
            movingProjectile();
        }

    }


    private void movingProjectile()
    {

        transform.Translate( new Vector2(0,1)*speed* Time.deltaTime); 
        
        bool colision =checkColisions();
        if (colision)
        {
            GetComponentInChildren<amoDestrction>().collisionDetected(gameObject.name);
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
            int inside = ray + 1;
            //int inside = ray + 1;
          //  Debug.Log(distance);
           // Debug.Log(inside);
            if (inside > distance )
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
