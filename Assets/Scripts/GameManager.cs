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
public enum Escenas { MainMenu, SecondaryMenu, Game }
public class GameManager : MonoBehaviour
{
    //SINGLETON
    public static GameManager instance;

    public PlayerConfig playerConfig;
    public TouchManager touchManager;
    public AudioSource audioSource;
    public GameObject MenuCargaPrefab;
    public MenuController menuController;
 
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
        //yield return new WaitForSeconds(1);
        AsyncOperation op = SceneManager.LoadSceneAsync(scene.ToString());
        GameObject sliderCargaObject = menuController.InicializarMenuDeCarga(MenuCargaPrefab);
        Slider sliderCarga = sliderCargaObject.transform.GetChild(0).gameObject.GetComponent<Slider>();


        while (!op.isDone)
        {
            //sliderCarga.value = op.progress;
            yield return null;
        }
    }
}
