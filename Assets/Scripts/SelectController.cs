using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject gameMod;
    public GameController game;
    public GunController gun;

    // number representing currently selected option:
    // 1 = shoot
    // 0 = reload
    public int optionSelection;

    // number representing currently selected player:
    // 1 = 1 (yourself)
    // 2 = 2
    // 3 = 3
    // 4 = 4
    public int playerSelection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        optionSelection = 1;
        playerSelection = 3;
        game = GetComponent<GameController>();
        gun = GetComponent<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.roundOrder[game.nextOrder] == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                optionSelection = Mathf.Min(optionSelection + 1, 1);
                Debug.Log("option: " + optionSelection);
                Debug.Log("player: " + playerSelection);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                playerSelection = (playerSelection + 2) % 4 + 1;
                Debug.Log("option: " + optionSelection);
                Debug.Log("player: " + playerSelection);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                optionSelection = Mathf.Max(optionSelection - 1, 0);
                Debug.Log("option: " + optionSelection);
                Debug.Log("player: " + playerSelection);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                playerSelection = playerSelection % 4 + 1;
                Debug.Log("option: " + optionSelection);
                Debug.Log("player: " + playerSelection);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                // shoot
                if (optionSelection == 1)
                {
                    gun.Shoot(playerSelection, 0);
                }
                // reload
                {

                }
                Debug.Log("option: " + optionSelection);
                Debug.Log("player: " + playerSelection);
            }
        }
    }
}
