using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum attacks { attack1, attack2}
public class AIEnemyAction : AICharacterController
{
    void Start()
    {
        this.loadComponents();
    }

    public void attack(string name) 
    {
        this.enemy.animator.Play(name);
    }
    /*public override void LoadComponent()
    {
        base.LoadComponent();
    }
    public void Attack()
    {
        enemy.Attack();
    }
    public void Flinch()
    {
        enemy.Flinch();
    }
    public void Death()
    {
        enemy.Death();
    }*/
}
