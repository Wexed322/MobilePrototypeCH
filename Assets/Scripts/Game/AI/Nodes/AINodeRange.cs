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


    public override TaskStatus OnUpdate()
    {
        if (aiSensor.getDistance() < minRangeToAttack)//dentro del rango, pegues idk
        {
            return TaskStatus.Failure;
        }
        else //fuera del rango pases al siguiente nodo, caminando
        {
            return TaskStatus.Success;
        }
    }
}

