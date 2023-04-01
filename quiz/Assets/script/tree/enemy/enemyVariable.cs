using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyVariable : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask groundLayer;
    public float jumpHeight;
    public float speed;
    public bool isGrounded;
    public float distanceFromGround;
    public bool canProgress = true;
    public GameObject rightHoleDetection;
    public GameObject limitRight;
    public GameObject limiteLeft;
    public GameObject LeftHoleDetection;
    public GameObject[] listRayPointOver;
    public GameObject target;
    public float distenceFromTarget;
    public bool canShoot;
    public bool canActe = false;

    public bool tookhisShot = false;
}
