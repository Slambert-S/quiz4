using System.Collections.Generic;
using BehaviorTree;

public class enemyBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;
    public enemyVariable _variableList;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            //TODO :Add attack behavior
            new Sequence(new List<Node>
            {
                new taskMove(transform, _variableList)
               //TODO: Add check enemy and go to behavior
            }),
        

       // new TaskPatrol(transform, waypoints)
        }); ;

        return root;
    }



    protected override void CustumUpdate()
    {
        //throw new System.NotImplementedException();
    }
}
