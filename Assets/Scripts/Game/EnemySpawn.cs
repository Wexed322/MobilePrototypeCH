using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<Enemy> enemies;
    public Enemy current;
    void Start()
    {
        for (int i = 1; i < enemies.Count; i++)
        {
            enemies[i].gameObject.SetActive(false);
        }

        this.current = enemies[0];
    }

    void Update()
    {
        
    }

    public void nextEnemy(Enemy current) 
    {
        current.gameObject.SetActive(false);
        enemies.Remove(current);

        if (enemies.Count > 0) 
        {
            this.current = enemies[0];
            enemies[0].gameObject.SetActive(true);
        }
        
    }
}
