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
        //this.transform.position =  Vector2.MoveTowards(this.transform.position, goal.position, 0);
        Debug.Log("ananana");
    }
}
