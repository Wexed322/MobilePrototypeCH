using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {Fuerza, Magia, Agilidad}
public class Enemy : MonoBehaviour
{
    Player referencePlayer;
    Animator animator;
    public bool vulnerable;
    public float damage;
    public float health;
    public EnemyType myType;
    //BOMBAS DE HUMO, BLUR
    //PODER DE REGRESAR EL TIEMPO
    //HACER ABUELO AL RIVAL Y REDUCIR SUS STATS

    private void Awake()
    {
        
    }
    void Start()
    {
        animator = GetComponent<Animator>();
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
    public void Attack()
    {
        animator.SetTrigger("Attack");
        referencePlayer.TryAttack();
    }
    public void Flinch()
    {
        animator.SetTrigger("Countered");
        ReceiveDamage();
    }
    void ReceiveDamage()
    {
        health = health - referencePlayer.damage;
    }
    public void Death()
    {
        animator.SetBool("IsDead", true);
    }
    public void setVulnerability() 
    {
        vulnerable = !vulnerable;
    }
}
