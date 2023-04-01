using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public int speed = 5;
    Vector2 direction;
    public bool checkMoving = false;
    public float hitbox;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 direction = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void movingProjectile()
    {

        transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime);

        bool colision = checkColisions();
        if (colision)
        {
            GetComponent<amoDestrction>().collisionDetected();
        }

    }

    public bool checkColisions()
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
            float inside = hitbox + 1.2f;
            float outside = hitbox - 1.2f;

            if (inside > distance)
            {

                Debug.Log(childe.name);
                
                return true;
            }

           
        }

        for (int j = 0; j < nbChildWall; j++)
        {
            GameObject childe = parentOfWall.transform.GetChild(j).gameObject;
            distance = Vector2.Distance(childe.transform.position, position);

            //Change later to use radius of the object
            float inside = hitbox + 1.2f;
            float outside = hitbox - 1.2f;

            if (inside > distance)
            {

               

                return true;
            }

          



            //Debug.Log(childe.name);
        }
        return false;
    }
}
