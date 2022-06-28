using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class AINodeDeath : AINodeAction
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (this.AIEnemyAction.enemy.health > 0)
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}
