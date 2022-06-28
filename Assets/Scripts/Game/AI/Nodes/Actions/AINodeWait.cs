using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class AINodeWait : AINodeAction
{
    float realTimeToWait;
    public float timeToWait;
    public float random;
    public override void OnStart()
    {
        base.OnStart();
        realTimeToWait = Random.Range(timeToWait - random, timeToWait + random);
    }
    public override TaskStatus OnUpdate()
    {
        realTimeToWait -= Time.deltaTime;
        while (realTimeToWait > 0)
            return TaskStatus.Running;
        return TaskStatus.Success;
    }
}
