using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //public testScriptable testScriptable_;
    //public testScriptable testScriptable_2;
    //public HealthBar healthBar;
    [SerializeField] Text ScoreText;
    [SerializeField] Text TimeText;
    [SerializeField] Text VidasText;
    Animator animator;
    SpriteRenderer sr;
    PlayerConfig playerSettings;
    public Enemy currentEnemyReference;
    public int vidas;
    public float damage;
    public float vida;
    public float resistencia;
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

    void Start()
    {
        playerSettings = GameManager.instance.playerConfig;
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        if (playerSettings != null)
        {
            vida = playerSettings.vida;
            damage = playerSettings.damage;
            resistencia = playerSettings.resistencia;
            sr.color = playerSettings.color;
        }
        score = 0;
        SetScore();
        vidas = 3;
        SetVidas();

        //healthBar.SetMaxHealth(vida);
    }

    void ReceiveDamage(float damage)
    {
        animator.SetTrigger("Flinch");
        vidas--;
        SetVidas();
        vida -= damage;
        //healthBar.SetHealth(vida);
        if (vidas <= 0) 
        {
            GameManager.instance.GameOver();
        }
           

    }

    public void DealDamage()
    {
        currentEnemyReference.Flinch();
    }
    public void TryAttack()
    {
        if(this.tag == "Block")
        {
            ReceiveDamage(currentEnemyReference.damage/2);
        }
        else if(this.tag == "Parry")
        {

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
        animator.SetTrigger("Counter");
        score++;
        SetScore();
    }
    public void PauseButton()
    {
        GameManager.instance.Pause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("ANACHEI");
            animator.SetTrigger("Block");
        }
            

#if UNITY_ANDROID
        TimeText.text = string.Format("Time alive: {0}", Time.timeSinceLevelLoad.ToString("0.00")); 
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
            GameManager.instance.Pause();
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
