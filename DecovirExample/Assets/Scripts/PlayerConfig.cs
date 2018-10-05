using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float sizeX;
    [SerializeField]
    private float sizeY;
    [SerializeField] private GameObject PlayerCell;


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
                Instantiate<GameObject>(PlayerCell, new Vector2(20 * j, 20 * i), Quaternion.identity, transform);
            }
        }
    }
}
