using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacterController : MonoBehaviour
{
    public Enemy enemy;

    public void loadComponents() 
    {
        enemy = GetComponent<Enemy>();
    }
}
