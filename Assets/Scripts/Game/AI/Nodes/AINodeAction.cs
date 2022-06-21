using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class AINodeAction : Action
{
    protected AIEnemyAction AIEnemyAction;

    public override void OnStart()
    {
        AIEnemyAction = GetComponent<AIEnemyAction>();
    }
}
