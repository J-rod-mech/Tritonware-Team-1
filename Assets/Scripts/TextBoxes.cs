using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;
using System.Collections;

public class TextBoxes : MonoBehaviour
{
    public TMP_Text displayText;

    public GameObject gameMod;

    public GameController game;

    public SelectController select;

    public bool interrupt;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameMod = GameObject.Find("GameMod");
        game = gameMod.GetComponent<GameController>();
        displayText = GetComponent<TMP_Text>();
        select = gameMod.GetComponent<SelectController>();
        interrupt = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator delayText()
    {
        yield return new WaitForSeconds(2f);
        displayActionList();
    }
    public void onPlayerTurn()
    {
        displayText.text = "Player " + game.roundOrder[game.nextOrder] + "\'s turn";
    }
    public void displayActionList()
    {
        String optionText;
        if (select.optionSelection == 1)
        {
            optionText = "Choosing to shoot Player " + select.playerSelection;
        }
        else
        {
            optionText = "Choosing to reload          ";
        }
        displayText.text = Environment.NewLine + "                         " + optionText + "   [SPACE] confirm" + Environment.NewLine + "[W] option shoot" +
        Environment.NewLine + "[A] target left             [S] option reload         [D] target right";
    }

    public void displayShotMSG(int hitPlayer, int playerTurn, int dmg)
    {
        displayText.text = Environment.NewLine + "Player " + playerTurn + " shot Player " + hitPlayer + " for " + dmg + " damage";
    }

    public void addKillMSG(int hitPlayer)
    {
        displayText.text += Environment.NewLine + "Player " + hitPlayer + " has been killed";
    }

    public void displayReloadMSG(int playerTurn)
    {
        displayText.text = Environment.NewLine + "Player " + playerTurn + " reloaded";
    }
}
