using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "playerConfig", menuName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public int id;
    public float vida;
    public float damage;
    public float resistencia;
}
