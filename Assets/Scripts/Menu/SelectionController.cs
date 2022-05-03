using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionController : MonoBehaviour
{
    [SerializeField] PlayerConfig finalPlayerConfig;
    [SerializeField] List<GameObject> listaCharacters;
    [SerializeField] List<PlayerConfig> listaPlayerConfig;
    [SerializeField] int index;
    void Start()
    {
        finalPlayerConfig = listaPlayerConfig[0];
        StartGameEvent.eventosParaIniciarJuego += SendPlayerConfig;
    }

    void Update()
    {
        direccionSwipe swipe = GameManager.instance.touchManager.SwipeDirection();
        if (swipe == direccionSwipe.derecha)
        {
            ActiveCharacter(-1);
        }
        else if (swipe == direccionSwipe.izquierda)
        {
            ActiveCharacter(1);
        }
        else 
        {
            
        }

    }
    public void SendPlayerConfig() 
    {
        GameManager.instance.playerConfig = finalPlayerConfig;
    }
    public void ActiveCharacter(ButtonController a) 
    {
        listaCharacters[index].gameObject.SetActive(false);
        index += a.entero;
        if (index >= 0)
        {
            index = index % listaCharacters.Count;
        }
        else 
        {
            index = listaCharacters.Count + index;
        }

        finalPlayerConfig = listaPlayerConfig[index];
        listaCharacters[index].gameObject.SetActive(true);
    }


    public void ActiveCharacter(int a)
    {
        listaCharacters[index].gameObject.SetActive(false);
        index += a;
        if (index >= 0)
        {
            index = index % listaCharacters.Count;
        }
        else
        {
            index = listaCharacters.Count + index;
        }
        finalPlayerConfig = listaPlayerConfig[index];
        listaCharacters[index].gameObject.SetActive(true);
    }
}
