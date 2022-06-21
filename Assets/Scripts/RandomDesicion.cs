using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnumAttack { attack1, attack2, attack3, attack4 }
public class GetRandomEnum<T>
{
    static System.Random _R = new System.Random();

    public static T RandomEnumValue()
    {
        var v = Enum.GetValues(typeof(T));
        Debug.Log(v);
        return (T)v.GetValue(_R.Next(v.Length));
    }

}
