using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vida;
    public float damage;
    public float resistencia;
    public PlayerConfig playerSettings;
    void Start()
    {
        playerSettings = GameManager.instance.playerConfig;

        if (playerSettings != null) 
        {
            vida = playerSettings.vida;
            damage = playerSettings.damage;
            resistencia = playerSettings.resistencia;
        }
    }

    void Update()
    {
        
    }
}
