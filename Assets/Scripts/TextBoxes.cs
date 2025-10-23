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

    public GameObject p1HP;
    public GameObject p2HP;
    public GameObject p3HP;
    public GameObject p4HP;
    public TMP_Text player1Text;
    public TMP_Text player2Text;
    public TMP_Text player3Text;
    public TMP_Text player4Text;

    public bool interrupt;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameMod = GameObject.Find("GameMod");
        game = gameMod.GetComponent<GameController>();
        displayText = GetComponent<TMP_Text>();
        select = gameMod.GetComponent<SelectController>();
        p1HP = GameObject.Find("HPTXT1");
        p2HP = GameObject.Find("HPTXT2");
        p3HP = GameObject.Find("HPTXT3");
        p4HP = GameObject.Find("HPTXT4");
        player1Text = p1HP.GetComponent<TMP_Text>();
        player2Text = p2HP.GetComponent<TMP_Text>();
        player3Text = p3HP.GetComponent<TMP_Text>();
        player4Text = p4HP.GetComponent<TMP_Text>();
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

    public void DisplayHealth()
    {
        player1Text.text = game.getStats(1).hp > 0 ? "X " + game.getStats(1).hp: "";
        player2Text.text = game.getStats(2).hp > 0 ? "X " + game.getStats(2).hp: "";
        player3Text.text = game.getStats(3).hp > 0 ? "X " + game.getStats(3).hp: "";
        player4Text.text = game.getStats(4).hp > 0 ? "X " + game.getStats(4).hp: "";
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
            optionText = "     Choosing to reload     ";
        }
        displayText.text = Environment.NewLine + "                         " + optionText + "   [SPACE] confirm" + Environment.NewLine + "[W] option shoot" +
        Environment.NewLine + "[A] target left             [S] option reload         [D] target right";
    }

    public void displayShotMSG(int hitPlayer, int playerTurn, int dmg)
    {
        displayText.text = Environment.NewLine + "Player " + playerTurn + " shoots Player " + hitPlayer + " for " + dmg + " damage";
    }

    public void addKillMSG(int hitPlayer)
    {
        displayText.text += Environment.NewLine + "Player " + hitPlayer + " has been killed";
    }

    public void displayReloadMSG(int playerTurn)
    {
        displayText.text = Environment.NewLine + "Player " + playerTurn + " reloads and spins the barrel";
    }
}
