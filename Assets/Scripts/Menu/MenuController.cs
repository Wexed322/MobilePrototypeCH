using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject PanelReference;
    public List<GameObject> Menus;
    bool isPaused;

    public TransitionScene transitionScene_;
    public GameObject PausePanel;
    public GameObject PauseGameOver;
    void Start()
    {
        if (GameManager.instance != null) 
        {
            GameManager.instance.menuController = this;
        }
      
        if (Menus.Count > 0) 
        {
            Menus[0].gameObject.SetActive(true);
        }

        PanelReference = this.transform.gameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Pause();
    }

    public void goCharacterSelection()
    {
        GameManager.instance.loadScene(Escenas.SecondaryMenu);
    }
    public void goStartGame() 
    {
        Time.timeScale = 1f;
        StartGameEvent.eventosParaIniciarJuego?.Invoke();
        GameManager.instance.loadScene(Escenas.Game);
    }

    public void goMenu()
    {
        Time.timeScale = 1f;
        GameManager.instance.loadScene(Escenas.MainMenu);
    }

    public void setVolumePref(Slider input) 
    {
        PlayerPrefs.SetFloat("VolumenGlobal", input.value);
    }

    public void setBrilloPref(Slider input)
    {
        PlayerPrefs.SetFloat("BrilloGlobal", Mathf.Clamp(1-input.value,0f,0.8f));
    }

    public void setBrillo(Image input)
    {

        input.color = new Color(input.color.r, input.color.g, input.color.b, PlayerPrefs.GetFloat("BrilloGlobal"));
    }

    public GameObject InicializarMenuDeCarga(GameObject prefab) 
    {
        foreach (var item in Menus)
        {
            item.gameObject.SetActive(false);
        }

        GameObject menuCarga =  Instantiate(prefab, PanelReference.transform);
        return menuCarga;
    }

    public void Pause()
    {
        PausePanel.SetActive(GameManager.instance.isPaused);
    }

    public void GameOver()
    {
        PauseGameOver.SetActive(GameManager.instance.gameOver);
    }

}
