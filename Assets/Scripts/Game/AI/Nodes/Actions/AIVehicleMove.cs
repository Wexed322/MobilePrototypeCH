using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVehicleMove : AINodeVehicle
{
    public float distanceToStop;
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        this.AIEnemyVehicle.enemy.animator.Play("Run");
        AIEnemyVehicle.GoToPosition(distanceToStop);
        return TaskStatus.Success;
    }
}
