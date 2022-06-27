using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class AINodeVehicle : Action
{
    protected AIEnemyVehicle AIEnemyVehicle;
    public override void OnStart()
    {
        AIEnemyVehicle = GetComponent<AIEnemyVehicle>();
    }

}
