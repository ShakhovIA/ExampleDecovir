using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureLogic : MonoBehaviour {

    [SerializeField] private PlayerConfig URLPlayerCfg;

    private void LateUpdate()
    {
        if(gameObject.transform.position.y<=URLPlayerCfg.transform.position.y)
        {
            for (int i = 0; i < URLPlayerCfg.SizeX; i++)
                if (gameObject.transform.position.x >= URLPlayerCfg.transform.position.y + 20 * i)
                {
                    //Destroy(gameObject);
                    gameObject.SetActive(false);
                }
        }
    }
}
