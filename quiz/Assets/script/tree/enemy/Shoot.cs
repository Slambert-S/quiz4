using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class Shoot : Node
{
    // Start is called before the first frame update

    private Transform _transform;
    private enemyVariable _variableList;
    public Shoot(Transform transform, enemyVariable variableList)
    {
        _transform = transform;
        _variableList = variableList;
        //_animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        
        if(_variableList.tookhisShot == true)
        {
            return NodeState.SUCCESS;
        }
        if (_variableList.canShoot == true)
        {
            Vector2 direction = _variableList.target.transform.position - _transform.position  ;

            // Calculate the angle between the two points
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.gameObject.GetComponent<aiShoot>().shootEnemy(angle, 0);
            _variableList.canShoot = false;
            _variableList.tookhisShot = true;
            _variableList.canActe = false;
            GameObject.Find("gameManager").GetComponent<turnManager>().aiEndTurn();


        }
        else
        {
            return NodeState.FAILURE;
        }
        return NodeState.SUCCESS;
    }
}
