using System;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    public GameObject gameMod;
    public GameController game;
    public GunController gun;
    public GameObject text;
    public TextBoxes textbox;
    public GameObject sound;
    public AudioPlayer audioPlayer;

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
        gameMod = GameObject.Find("GameMod");
        game = gameMod.GetComponent<GameController>();
        gun = gameMod.GetComponent<GunController>();
        text = GameObject.Find("DialogueText");
        textbox = text.GetComponent<TextBoxes>();
        sound = GameObject.Find("Sound");
        audioPlayer = sound.GetComponent<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.nextOrder < 4 && game.roundOrder[game.nextOrder] == 1)
        {
            if (optionSelection == 0 && Input.GetKeyDown(KeyCode.W))
            {
                audioPlayer.SelectAudio();
                optionSelection = Mathf.Min(optionSelection + 1, 1);
                textbox.displayActionList();
            }
            else if (optionSelection == 1 && Input.GetKeyDown(KeyCode.A))
            {
                audioPlayer.SelectAudio();
                playerSelection = (playerSelection + 2) % 4 + 1;
                // moves on to next alive player if current target is dead
                while (!game.playersStatus[playerSelection - 1])
                {
                    playerSelection = (playerSelection + 2) % 4 + 1;
                }
                textbox.displayActionList();
            }
            else if (optionSelection == 1 && Input.GetKeyDown(KeyCode.S))
            {
                audioPlayer.SelectAudio();
                optionSelection = Mathf.Max(optionSelection - 1, 0);
                textbox.displayActionList();
            }
            else if (optionSelection == 1 && Input.GetKeyDown(KeyCode.D))
            {
                audioPlayer.SelectAudio();
                playerSelection = playerSelection % 4 + 1;
                // moves on to next alive player if current target is dead
                while (!game.playersStatus[playerSelection - 1])
                {
                    playerSelection = playerSelection % 4 + 1;
                }
                textbox.displayActionList();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                // shoot
                if (optionSelection == 1)
                {
                    if (gun.ammo > 0)
                    {
                        gun.Shoot(playerSelection, 1);
                    }
                    else
                    {
                        Debug.Log("Can\'t shoot - out of ammo");
                    }
                }
                // reload
                else {
                    if (gun.ammo < 6)
                    {
                        gun.Reload(1); 
                    }
                    else
                    {
                        Debug.Log("Can\'t reload - ammo full");
                    }
                }
                Debug.Log("option: " + optionSelection);
                Debug.Log("player: " + playerSelection);
            }
        }
    }

    //public bool optionSelect()
    //{
        
    //}
}
