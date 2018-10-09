using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZone : MonoSingleton<PlayZone> {

    static public int M=40;
    static public int N=30;
    static public int CurrentZonePlay = 0;
    [SerializeField] private GameObject Cell;
    [SerializeField] private Transform Parent;


    public void InitializeGameZone()
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
