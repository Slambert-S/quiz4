using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fellInVoid : MonoBehaviour
{
    bool player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (transform.position.y <= -7)
        {
            if(player == true)
            {
                GameObject.Find("gameManager").GetComponent<turnManager>().playerEndTurn();
                GameObject.Find("gameManager").GetComponent<turnManager>().bullethit();

            }
            else
            {
                GameObject.Find("gameManager").GetComponent<turnManager>().aiEndTurn();
                GameObject.Find("gameManager").GetComponent<turnManager>().bullethit();
            }
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    
}
