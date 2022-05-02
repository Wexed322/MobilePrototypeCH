using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "randomData", menuName = "testScriptable")]
public class testScriptable : ScriptableObject
{
    /*private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;//?????
    }*/
    public int vida;
    public int muertes;
    public string name_;
}
