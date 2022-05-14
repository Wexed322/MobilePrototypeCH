using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBrillo : MonoBehaviour
{
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, PlayerPrefs.GetFloat("BrilloGlobal"));
    }
    void Update()
    {
        
    }
}
