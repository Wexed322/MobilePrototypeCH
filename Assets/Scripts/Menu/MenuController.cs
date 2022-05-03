using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    void Start()
    {

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
}
