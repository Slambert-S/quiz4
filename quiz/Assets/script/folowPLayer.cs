using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folowPLayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        if(player != null)
        {

            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
        }
    }
}
