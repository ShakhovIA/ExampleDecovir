using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigureConfig : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float sizeX;
    [SerializeField]
    private float sizeY;
    [SerializeField] private GameObject FigureCell;
    [SerializeField] private Text numText;

    public int Num;

    public float Speed
    {
        get { return speed; }
        set
        {
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

    public Text NumText
    {
        get { return numText; }
        set
        {
            try
            {
                numText = value;
            }
            catch { }
        }
    }

    public void CreateFigure()
    {
        GameObject Temp = Instantiate<GameObject>(gameObject, transform.parent);

        for (int i = 0; i < SizeY; i++)
        {
            for (int j = 0; j < SizeX; j++)
            {
                var obj=Instantiate<GameObject>(FigureCell, new Vector2(transform.position.x +20 * j, transform.position.y+ 20 * i), Quaternion.identity, Temp.transform);
                if (i + 1 == SizeY && j + 1 == SizeX)
                {
                    Temp.transform.position = new Vector2(Random.Range(20 * Random.Range(0, (int)PlayZone.N - sizeX), (PlayZone.N * 20) - (obj.transform.position.x + 20)), Temp.transform.position.y);
                }
                obj.transform.SetSiblingIndex(0);
            }
        }

        StartCoroutine(GravityStart(Temp));
        
    }

    public IEnumerator GravityStart(GameObject temp)
    {

        while(temp != null&&temp.transform.position.y>-60)
        {
            yield return new WaitForSeconds(0.7f/Speed);
            if(temp != null)
            temp.transform.position = new Vector2(temp.transform.position.x, temp.transform.position.y - 20);
        }
        if(temp != null)
            Destroy(temp);
    }
}
