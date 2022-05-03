using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject PanelReference;
    public List<GameObject> Menus;
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
        
    }

    public void CharacterSelection()
    {
        GameManager.instance.loadScene(Escenas.SecondaryMenu);
    }
    public void StartGame() 
    {
        StartGameEvent.eventosParaIniciarJuego?.Invoke();
        GameManager.instance.loadScene(Escenas.Game);
    }

    public void setVolumePref(Slider input) 
    {
        PlayerPrefs.SetFloat("VolumenGlobal", input.value);
    }

    public void setBrilloPref(Slider input)
    {
        PlayerPrefs.SetFloat("BrilloGlobal", Mathf.Clamp(input.value,0f,0.8f));
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
}
