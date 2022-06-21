using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class AINodeRange : Action
{
    protected AISensor aiSensor;
    public float minRangeToAttack;

    public override void OnStart()
    {
        aiSensor = GetComponent<AISensor>();
    }
    /*public override TaskStatus OnUpdate()
    {
        if (aiSensor.getDistance() < minRangeToAttack) 
        {
            return TaskStatus.Success;
        }
    }*/
}
