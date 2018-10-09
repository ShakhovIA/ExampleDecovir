using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureLogic : MonoBehaviour
{

    [SerializeField] private PlayerConfig URLPlayerCfg;
    [SerializeField] private FigureConfig URLFigureCfg;
    private bool isLive = true;

    private void Update()
    {
        if (gameObject.transform.position.y <= URLPlayerCfg.transform.position.y)
        {
            for (int i = 0; i < URLPlayerCfg.SizeY; i++)
                for (int j = 0; j < URLPlayerCfg.SizeX; j++)
                {
                    if (gameObject.transform.position.x >= URLPlayerCfg.transform.position.x)
                    {
                        for (int a = 0; a < URLFigureCfg.SizeX; a++)
                        {
                            if (gameObject.transform.position.x + (20 * a) <= URLPlayerCfg.transform.position.x + (20 * URLPlayerCfg.SizeX))
                            {
                                if (isLive)
                                {
                                    if (URLFigureCfg.Num == URLPlayerCfg.NeedNum)
                                    {
                                        XMLReader.Instance().NextWave(PlayZone.CurrentZonePlay);
                                        ScoreUpdater.Instance().Score++;
                                        ScoreUpdater.Instance().UpdScore();

                                    }
                                    else
                                    {
                                        ScoreUpdater.Instance().YouLose();

                                    }
                                    isLive = false;
                                    foreach(var Temp in MetaData.Instance().AllLiveFigures)
                                    {
                                        Destroy(Temp, 0.05f);
                                    }
                                    MetaData.Instance().AllLiveFigures.Clear();
                                }
                            }
                        }
                    }
                    else if (gameObject.transform.position.x <= URLPlayerCfg.transform.position.x)
                    {
                        for (int a = 0; a < URLFigureCfg.SizeX; a++)
                        {
                            if (gameObject.transform.position.x + (20 * a) >= URLPlayerCfg.transform.position.x)
                            {
                                if (isLive)
                                {
                                    if (URLFigureCfg.Num == URLPlayerCfg.NeedNum)
                                    {
                                        XMLReader.Instance().NextWave(PlayZone.CurrentZonePlay);
                                        ScoreUpdater.Instance().Score++;
                                        ScoreUpdater.Instance().UpdScore();
                                    }
                                    else
                                    {
                                        ScoreUpdater.Instance().YouLose();
                                    }

                                    isLive = false;
                                    foreach (var Temp in MetaData.Instance().AllLiveFigures)
                                    {
                                        Destroy(Temp, 0.05f);
                                    }
                                    MetaData.Instance().AllLiveFigures.Clear();

                                }
                            }
                        }
                    }
                }
        }
    }
}
