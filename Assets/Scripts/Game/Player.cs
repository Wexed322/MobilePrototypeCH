using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //public testScriptable testScriptable_;
    //public testScriptable testScriptable_2;
    Animator animator;
    public Enemy currentEnemyReference;
    public float damage;
    public float vida;
    public float currentCoins;
    public float currentDiamonds;
    //ARMA
    //STATS DE VELOCIDAD DE ATAQUE??, MAS VIDA, POWER UP
    private void Awake()
    {
        
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ReceiveDamage(float damage)
    {
        animator.SetTrigger("Flinch");
        vida -= damage;
    }
    public void TryAttack()
    {
        if(this.tag == "Block")
        {
            ReceiveDamage(currentEnemyReference.damage/2);
        }
        else if(this.tag == "Parry")
        {
            currentEnemyReference.Flinch();
            Counter();
        }
        else
        {
            ReceiveDamage(currentEnemyReference.damage);
        }

    }

    void Counter()
    {
        animator.SetTrigger("Attack");
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if (currentEnemyReference.vulnerable) 
            {
                Debug.Log("daño");
            }
        }

        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 0) 
        {
            testScriptable_ = testScriptable_2;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            testScriptable_.muertes = SceneManager.GetActiveScene().buildIndex + 1;
            testScriptable_.vida -= SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            testScriptable_.muertes = SceneManager.GetActiveScene().buildIndex - 1;
            testScriptable_.vida += SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }*/
    }
}
