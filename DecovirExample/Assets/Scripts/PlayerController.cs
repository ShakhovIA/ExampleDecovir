using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private PlayerConfig URLPlayerCfg;

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
                if (Input.GetKey(KeyCode.D)&& transform.position.x+(20*URLPlayerCfg.SizeX) < (PlayZone.N)*20)
                {
                    transform.position = new Vector2(transform.position.x + 20, transform.position.y);
                }
                else if (Input.GetKey(KeyCode.A)&& transform.position.x > 0)
                {
                    transform.position = new Vector2(transform.position.x - 20, transform.position.y);
                }
    }
}
