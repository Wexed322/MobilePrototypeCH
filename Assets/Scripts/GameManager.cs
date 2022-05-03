using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameEvent
{
    public static System.Action eventosParaIniciarJuego;

    /*public static System.Action<string, string, string> eventoMuerteString;//eventoConparametros*/
}
public enum Escenas { MainMenu, SecondaryMenu, Game }
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerConfig playerConfig;
    public TouchManager touchManager;
    private void Awake()
    {
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
    public void loadScene(Escenas scene) 
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
