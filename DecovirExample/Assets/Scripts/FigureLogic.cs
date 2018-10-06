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
                                //Destroy(gameObject);
                                print("intersect1");
                                if (URLFigureCfg.Num == URLPlayerCfg.NeedNum)
                                {
                                    print("OK");
                                    StopAllCoroutines();

                                }
                                else print("neOK");
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
                                //Destroy(gameObject);
                                print("intersect2");
                                if (URLFigureCfg.Num == URLPlayerCfg.NeedNum)
                                {
                                    print("OK");
                                    StopAllCoroutines();
                                }
                                else print("neOK");
                                gameObject.SetActive(false);
                            }
                        }
                    }
                }      
        }
    }
}
