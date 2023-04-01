using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float speed = 5f; // speed of the character
    public float jumpHeight = 2f; // height of the character's jump
    public float groundDistance = 2.0f; // distance from the character's feet to the ground
    public LayerMask groundLayer; // the ground layer
    public bool isGrounded = false; // is the character on the ground?
    private Rigidbody2D rb; // reference to the character's rigidbody

    public int selectedWeapon = 0;
    private previewTrajectory prevTrajectory;

    private checkWallCollisions _wallDetection;
    public GameObject[] prefabWeapon;
    void Start()
    {
        // get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
        _wallDetection = gameObject.GetComponent<checkWallCollisions>();
        prevTrajectory = GetComponent<previewTrajectory>();
    }
  
    void Update()
    {
        
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
            updateWeapon(1);
            }
            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
            updateWeapon(-1);
            }

        if (Input.GetKeyDown("1")){
            selectedWeapon = 0;
            updateWeapon(0);
        }

        if (Input.GetKeyDown("2")){
            selectedWeapon = 1;
            updateWeapon(0);
        }

        if (Input.GetKeyDown("3"))
        {
            selectedWeapon = 2;
            updateWeapon(0);
        }


        // move the character left or right
        float move = Input.GetAxis("Horizontal");
        Vector3 lastPosition = transform.position; 
        transform.position += new Vector3(move * speed * Time.deltaTime, 0f, 0f);
        if (_wallDetection.touchingWall(0.25f))
        {
            transform.position = lastPosition;
        }
        
        // jump if the character is on the ground and the jump button is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // calculate the required upward velocity to achieve the desired jump height
            float jumpVelocity = Mathf.Sqrt(2f * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);

            isGrounded = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bullet = Instantiate(prefabWeapon[selectedWeapon], transform.position, Quaternion.identity);
            float angle = GetComponent<angleBetwenCursor>().getAngle();
            bullet.GetComponent<testBulledtArc>().launchAngle = angle;
            bullet.GetComponent<testBulledtArc>().readyToLaunch = true;
            if(selectedWeapon == 1)
            {
                if(angle <90 && angle >= -90)
                {

                    bullet.transform.Rotate(Vector3.forward * -90);
                }
                else
                {
                    bullet.transform.Rotate(Vector3.forward * 90);
                }
            }
        }

        // check if the character is grounded by casting a raycast downward
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        isGrounded = hit.collider != null;
    }

    private void updateWeapon(int direction)
    {
        selectedWeapon += direction;
        if(selectedWeapon  <= -1)
        {
            selectedWeapon = 2;
        }
        if(selectedWeapon >= 3)
        {
            selectedWeapon = 0;
        }

        switch (selectedWeapon)
        {
            
            case 0:
                print("Whadya want?");
                prevTrajectory.initialVelocity = 10;
                
                break;
            case 2:
                print("Grog SMASH!");
                prevTrajectory.initialVelocity = 30;
                break;
            case 1:
                print("Ulg, glib, Pblblblblb");
                prevTrajectory.initialVelocity = 15;
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }

    }
}

