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

    public void GoToPosition()
    {
        //this.enemy.animator.Play("LightBandit_Run");
        this.transform.position = Vector3.MoveTowards(this.transform.position, goal.position,0.02f);
    }
}
