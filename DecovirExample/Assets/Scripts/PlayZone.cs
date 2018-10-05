﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZone : MonoBehaviour {

    static public int M=40;
    static public int N=30;
    [SerializeField] private GameObject Cell;
    [SerializeField] private Transform Parent;

    private void Start()
    {
        InitializeGameZone();
    }

    private void InitializeGameZone()
    {
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Instantiate<GameObject>(Cell, new Vector2(20 * j, 20 * i), Quaternion.identity, Parent);
            }
        }
    }
}