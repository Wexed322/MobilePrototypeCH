using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {Fuerza, Magia, Agilidad}
public class Enemy : MonoBehaviour
{
    public Player referencePlayer;
    public float secondsBetweenAttacks;
    Animator animator;
    SpriteRenderer sr;
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
        sr = GetComponent<SpriteRenderer>();
        referencePlayer = FindObjectOfType<Player>();
        referencePlayer.currentEnemyReference = this;
        StartCoroutine("AttackTask");
        
        //this.GetComponent<Animator>().speed = 0.5f;
    }
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            this.GetComponent<Animator>().speed++;
        }*/
        
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");
        
    }
    public void AttackEvent()
    {
        referencePlayer.TryAttack();
    }
    public void Flinch()
    {
        animator.SetTrigger("Flinch");
        ReceiveDamage();
    }
    void ReceiveDamage()
    {
        health = health - referencePlayer.damage;
        if (health <= 0)
            Death();
    }
    public void Death()
    {
        animator.SetBool("IsDead", true);
    }
    public void setVulnerability() 
    {
        vulnerable = !vulnerable;
    }
    public void ChangeColor(int color)
    {
        switch (color)
        {
            case 1:
                sr.color = Color.red;
                break;
            case 2:
                sr.color = Color.blue;
                break;
            case 3:
                sr.color = Color.green;
                break;
            case 4:
                sr.color = Color.black;
                break;
            case 5:
                sr.color = Color.yellow;
                break;
            default:
                sr.color = Color.white;
                break;
        }
    }
    IEnumerator AttackTask()
    {
        float current = secondsBetweenAttacks;
        while (true)
        {
            if (current <= 0f)
            {
                Attack();
                current = secondsBetweenAttacks;
            }
            else
            {
                current -= Time.deltaTime;
            }
            yield return null;
        }

    }
}
