using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyAction : AIEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void LoadComponent()
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
    }
}
