using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public Enemy enemy;
    public virtual void LoadComponent()
    {
        enemy = GetComponent<Enemy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadComponent();
    }
}
