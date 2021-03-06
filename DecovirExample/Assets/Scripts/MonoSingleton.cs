﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T instance;

    public MonoSingleton()
    { }

    public static T Instance()
    {
        if (instance == null)
            instance = (T)FindObjectOfType(typeof(T));
        return instance;
    }

}
