using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    private Transform player;

    public void loadComponents(Enemy enemy) 
    {
        player = enemy.referencePlayer.transform;
    }
    public float getDistance() 
    {
        if (player != null)
        {
            return Vector3.Distance(this.transform.position, player.transform.position);
        }
        else 
        {
            return -10;
        }
    }
}
