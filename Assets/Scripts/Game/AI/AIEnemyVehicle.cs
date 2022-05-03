using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyVehicle : AIEnemy
{
    Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        goal = FindObjectOfType<EnemyPos>().transform;
    }
    public void GoToPosition()
    {
        Vector2.MoveTowards(this.transform.position, goal.position, 0);
    }
}
