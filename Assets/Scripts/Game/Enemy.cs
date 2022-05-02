using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {Fuerza, Magia, Agilidad}
public class Enemy : MonoBehaviour
{
    Player referencePlayer;
    public bool vulnerable;
    public float damage;
    public float vida;
    public EnemyType myType;
    //BOMBAS DE HUMO, BLUR
    //PODER DE REGRESAR EL TIEMPO
    //HACER ABUELO AL RIVAL Y REDUCIR SUS STATS


    void Start()
    {
        referencePlayer = FindObjectOfType<Player>();
        referencePlayer.currentEnemyReference = this;

        this.GetComponent<Animator>().speed = 0.5f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            this.GetComponent<Animator>().speed++;
        }
        
    }

    public void setVurnerability() 
    {
        vulnerable = !vulnerable;
    }
}
