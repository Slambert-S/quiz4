using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Task_selectTarget : Node
{
    private Transform _transform;
    private enemyVariable _variableList;
    public Task_selectTarget(Transform transform, enemyVariable variableList)
    {
        _transform = transform;
        _variableList = variableList;
        //_animator = transform.GetComponent<Animator>();
    }
    public override NodeState Evaluate()
    {
        GameObject parentOfsoldier = GameObject.Find("wormsList");
        int nbChildWorms = parentOfsoldier.transform.childCount;

        float curentMinDistance = float.MaxValue;
        GameObject closestEnemy = parentOfsoldier.transform.GetChild(0).gameObject;

        for (int i = 0; i < nbChildWorms; i++)
        {
            GameObject childe = parentOfsoldier.transform.GetChild(i).gameObject;
            if (childe.CompareTag("Player"))
            {

                float distance = Vector2.Distance(childe.transform.position, _transform.position);
                if (curentMinDistance > distance)
                {
                    curentMinDistance = distance;
                    closestEnemy = childe;
                }
            }

        }
        _variableList.target = closestEnemy;
        _variableList.distenceFromTarget = curentMinDistance;
        return NodeState.SUCCESS;
    }
}
