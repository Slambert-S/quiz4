using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class taskMove : Node
{
    private Transform _transform;
    private enemyVariable _variableList;
    public taskMove(Transform transform, enemyVariable variableList)
    {
        _transform = transform;
        _variableList = variableList;
        //_animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        bool needToJump = false;
        bool holeInground = false;
        LayerMask  ground = 6;
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, Vector2.down, _variableList.distanceFromGround, _variableList.groundLayer);
        _variableList.isGrounded = hit.collider != null;
        Debug.DrawRay(_transform.position, Vector2.down, Color.red);


        

        Vector2 direction = Vector2.left*-1;
        if (_variableList.canProgress == true)
        {
            Vector3 lastPosition = _transform.position;

            _transform.position += new Vector3(direction.x * _variableList.speed * Time.deltaTime, 0f, 0f);

        }



        //jump over obstacle

        //check if obstacle is in front of the player
        holeInground = checkForHole(direction.x );

        if (holeInground == true && _variableList.isGrounded == true)
        {
            //can make the Jump
            _variableList.canProgress = canJumpOverHole(direction.x);
        }
        else if (holeInground == false && _variableList.isGrounded == true)
        {
            _variableList.canProgress = true;
        }

        hit = Physics2D.Raycast(_transform.position, direction, _variableList.distanceFromGround, _variableList.groundLayer);
        Debug.DrawRay(_transform.position, direction, Color.red);
        bool blocked = hit.collider != null;

        if (blocked)
        {
            Debug.Log("is blocked");
            needToJump = checkSpaceForJump(direction);
        }

       
        //jump over hole
        if (_variableList.isGrounded )
        {
            if (needToJump || holeInground == true)
            {
                float jumpVelocity = Mathf.Sqrt(2f * _variableList.jumpHeight * Mathf.Abs(Physics2D.gravity.y));
                _transform.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(_transform.gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpVelocity);
                _variableList.isGrounded = false;
            }


        }

       
        return NodeState.SUCCESS;
    }

    public bool checkForHole(float direction)
    {
        GameObject holeDetector;
        if (direction == 1)
        {
            Debug.Log("Right hole detector");
             holeDetector = _variableList.rightHoleDetection;
        }else 
        {
            holeDetector = _variableList.LeftHoleDetection;
        }

        LayerMask ground = 6;
        RaycastHit2D hit = Physics2D.Raycast(holeDetector.transform.position, Vector2.down, 4, _variableList.groundLayer);

        if (hit.collider != null)
        {
            Debug.Log("Hole in the ground");
            return false;
        };
        return true;
    }

    public bool canJumpOverHole(float direction)
    {
        GameObject holeDetector;
        if (direction == 1)
        {
            holeDetector = _variableList.limitRight;
        }
        else
        {
            holeDetector = _variableList.limiteLeft;
        }

        LayerMask ground = 6;
        RaycastHit2D hit = Physics2D.Raycast(holeDetector.transform.position, Vector2.down, 4, _variableList.groundLayer);
        if (hit.collider == null)
        {
            return false;
        }
        return true;
    }

    public bool checkSpaceForJump(Vector2 direction)
    {
        GameObject[] listOfpoint = _variableList.listRayPointOver;
        int openSpace = 0;
        foreach (GameObject point in listOfpoint)
        {
            LayerMask ground = 6;
            RaycastHit2D hit = Physics2D.Raycast(point.transform.position, direction, 4, _variableList.groundLayer);
            Debug.DrawRay(_transform.position, direction *2, Color.red);
            if (hit.collider == null)
            {
                openSpace++;
            }

        }

        if(openSpace > 2)
        {
            return true;
        }
        return  false;
    }

        // Update is called once per frame
    
}
