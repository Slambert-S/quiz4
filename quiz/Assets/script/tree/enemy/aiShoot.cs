using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiShoot : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject[] prefabWeapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootEnemy( float angle, int weapon)
    {
        Debug.Log("pepiou");

        GameObject bullet = Instantiate(prefabWeapon[weapon], transform.position, Quaternion.identity);
        
        bullet.GetComponent<testBulledtArc>().launchAngle = angle;
        bullet.GetComponent<testBulledtArc>().readyToLaunch = true;
        
        
        if (weapon == 1)
        {
            if (angle < 90 && angle >= -90)
            {

                bullet.transform.Rotate(Vector3.forward * -90);
            }
            else
            {
                bullet.transform.Rotate(Vector3.forward * 90);
            }
        }
    }
}
