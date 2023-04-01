using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class waitForTurn : Node
{
    // Start is called before the first frame update
    private Transform _transform;
    private enemyVariable _variableList;
    public waitForTurn(Transform transform, enemyVariable variableList)
    {
        _transform = transform;
        _variableList = variableList;
        //_animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {

        if(_variableList.canActe == false)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }

    
}
