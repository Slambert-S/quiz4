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

    private checkWallCollisions _wallDetection;

    void Start()
    {
        // get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
        _wallDetection = gameObject.GetComponent<checkWallCollisions>();
    }
  
    void FixedUpdate()
    {
        // move the character left or right
        float move = Input.GetAxis("Horizontal");
        Vector3 lastPosition = transform.position; 
        transform.position += new Vector3(move * speed * Time.deltaTime, 0f, 0f);
        if (_wallDetection.touchingWall(0.5f))
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

        // check if the character is grounded by casting a raycast downward
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        isGrounded = hit.collider != null;
    }
}

