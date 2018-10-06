using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoSingleton<ScoreUpdater>
{
    [SerializeField] private Text Field;
    private int score;


    public int Score
    {
        get { return score; }
        set
        {
            try
            {
                if (value > 0)
                { score = value; }
            }
            catch { }
        }
    }
    public void UpdScore()
    {
        Field.text = "Score:" + Score.ToString();
    }

    public void YouLose()
    {
        Field.text = "You Lose";
    }
}
