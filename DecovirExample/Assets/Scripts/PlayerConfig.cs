﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConfig : MonoSingleton<PlayerConfig> {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float sizeX;
    [SerializeField]
    private float sizeY;
    [SerializeField] private GameObject PlayerCell;

    public int NeedNum;
    public Text MathExample;



    public float Speed
    {
        get { return speed; }
        set {
            try
            {
                if (value > 0)
                { speed = value; }
            }
            catch { }
            }
    }

    public float SizeX
    {
        get { return sizeX; }
        set
        {
            try
            {
                if (value > 0)
                { sizeX = value; }
            }
            catch { }
        }
    }

    public float SizeY
    {
        get { return sizeY; }
        set
        {
            try
            {
                if (value > 0)
                { sizeY = value; }
            }
            catch { }
        }
    }

    public void reSizePlayer()
    {
        for (int i = 0; i < SizeY; i++)
        {
            for (int j = 0; j <SizeX ; j++)
            {
                var Temp=Instantiate<GameObject>(PlayerCell, new Vector2(20 * j, 20 * i), Quaternion.identity, transform);
                Temp.transform.SetSiblingIndex(0);
            }
        }
    }
}
