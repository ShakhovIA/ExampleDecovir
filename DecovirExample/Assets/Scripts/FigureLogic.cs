using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureLogic : MonoBehaviour {

    [SerializeField] private PlayerConfig URLPlayerCfg;
    [SerializeField] private FigureConfig URLFigureCfg;

    private void LateUpdate()
    {
        if(gameObject.transform.position.y<=URLPlayerCfg.transform.position.y)
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
                                if (URLFigureCfg.Num == URLPlayerCfg.NeedNum)
                                {
                                    StopAllCoroutines();
                                    XMLReader.Instance().NextWave(PlayZone.CurrentZonePlay);
                                    ScoreUpdater.Instance().Score++;
                                    ScoreUpdater.Instance().UpdScore();

                                }
                                else
                                {
                                    ScoreUpdater.Instance().YouLose();
                                    StopAllCoroutines();
                                    Destroy(gameObject);
                                }
                                    gameObject.SetActive(false);
                            }
                        }
                    }
                    else if (gameObject.transform.position.x <= URLPlayerCfg.transform.position.x)
                    {
                        for (int a = 0; a < URLFigureCfg.SizeX; a++)
                        {
                            if (gameObject.transform.position.x + (20 * a) >= URLPlayerCfg.transform.position.x)
                            {

                                if (URLFigureCfg.Num == URLPlayerCfg.NeedNum)
                                {

                                    StopAllCoroutines();
                                    XMLReader.Instance().NextWave(PlayZone.CurrentZonePlay);
                                    ScoreUpdater.Instance().Score++;
                                    ScoreUpdater.Instance().UpdScore();
                                }
                                else
                                {
                                    ScoreUpdater.Instance().YouLose();
                                    StopAllCoroutines();
                                    Destroy(gameObject);
                                }
                                gameObject.SetActive(false);
                            }
                        }
                    }
                }      
        }
    }
}
