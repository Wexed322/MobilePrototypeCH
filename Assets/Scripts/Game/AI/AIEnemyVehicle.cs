using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyVehicle : AICharacterController
{
    public Transform goal;
    void Start()
    {
        this.loadComponents();
    }

    public void GoToPosition(float distanceToStop)
    {
        //this.enemy.animator.Play("LightBandit_Run");
        //if(Vector2.Distance(this.transform.position,goal.position)>distanceToStop)
            this.transform.position = Vector3.MoveTowards(this.transform.position, goal.position,0.02f);
    }
}
