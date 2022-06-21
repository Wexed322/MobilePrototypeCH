using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameEvent
{
    public static System.Action eventosParaIniciarJuego;

    /*public static System.Action<string, string, string> eventoMuerteString;//eventoConparametros*/
}

public class GameOverEvent
{
    public static System.Action eventosParaGameOver;

    /*public static System.Action<string, string, string> eventoMuerteString;//eventoConparametros*/
}
public enum Escenas { MainMenu, SecondaryMenu, Game, Game2_AI }
public class GameManager : MonoBehaviour
{

    //SINGLETON
    public static GameManager instance;


    
    public PlayerConfig playerConfig;
    public TouchManager touchManager;
    public AudioSource audioSource;
    public Animator FadePrefab;
    public MenuController menuController;
    public bool isPaused;
    public bool gameOver;
 
    private void Awake()
    {
        isPaused = false;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    /*public void loadScene(Escenas scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }*/

    public void loadScene(Escenas scene) 
    {
        StartCoroutine(LoadScene(scene));
    }
    IEnumerator LoadScene(Escenas scene)
    {
        menuController.transitionScene_.FadeIn();
        yield return new WaitForSeconds(1);

        AsyncOperation op = SceneManager.LoadSceneAsync(scene.ToString());

        
        while (!op.isDone)
        {

            yield return null;
        }

    }

    public void GameOver()
    {
        gameOver = true;
        menuController.GameOver();

        Time.timeScale = 0f;
    }

    public void Pause()
    {
        isPaused = !isPaused;
        menuController.Pause();
        if (isPaused)
            Time.timeScale = 0;
        if (!isPaused)
            Time.timeScale = 1;
    }
   
}
