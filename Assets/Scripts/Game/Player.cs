﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //public testScriptable testScriptable_;
    //public testScriptable testScriptable_2;
    //public HealthBar healthBar;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    [SerializeField] Text ScoreText;
    [SerializeField] Text TimeText;
    [SerializeField] Text VidasText;
    Animator animator;
    SpriteRenderer sr;
    public Enemy currentEnemyReference;
    public int vidas;
    public float damage;
    public float vida;
    public float currentCoins;
    public float currentDiamonds;
    public int score;
    bool isPaused;

    void SetScore()
    {
        ScoreText.text = string.Format("Score: {0}",this.score);
    }
    void SetVidas()
    {
        VidasText.text = string.Format("Vidas: {0}", this.vidas);
    }
    //ARMA
    //STATS DE VELOCIDAD DE ATAQUE??, MAS VIDA, POWER UP
    private void Awake()
    {
        
    }
    void Start()
    {
        isPaused = false;
        GameOverPanel.SetActive(false);
        score = 0;
        SetScore();
        vidas = 3;
        SetVidas();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //healthBar.SetMaxHealth(vida);
    }
    void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Pause()
    {
        isPaused = !isPaused;
        PausePanel.SetActive(isPaused);
        if (isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        
    }
    void ReceiveDamage(float damage)
    {
        animator.SetTrigger("Flinch");
        vidas--;
        SetVidas();
        vida -= damage;
        //healthBar.SetHealth(vida);
        if (vidas <= 0)
            GameOver();
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

    public void SetTag(string tag)
    {
        this.tag = tag;
    }
    public void ChangeColor(int color)
    {
        switch(color){
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

    void Counter()
    {
        animator.SetTrigger("Attack");
        score++;
        SetScore();
    }

    void Update()
    {
#if UNITY_ANDROID
        TimeText.text = string.Format("Time alive: {0}",Time.time.ToString("0.00")); 
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                animator.SetTrigger("Block");
            }
        }
#endif
#if UNITY_64
        TimeText.text = string.Format("Time alive: {0}",Time.time.ToString("0.00")); 
        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("Block");
        if (Input.GetKeyDown(KeyCode.P))
            Pause();
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
#endif
    }
}
