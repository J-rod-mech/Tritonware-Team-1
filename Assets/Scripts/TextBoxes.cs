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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameMod = GameObject.Find("GameMod");
        game = gameMod.GetComponent<GameController>();
        displayText = GetComponent<TMP_Text>();
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
        displayText.text = "Player " + game.roundOrder[game.nextOrder] + " \'s turn";
    }
    public void displayActionList()
    {
        displayText.text = "Available moves: " + Environment.NewLine + "W - shoot the gun" +
        Environment.NewLine + "S - reload the gun" + Environment.NewLine + "A - change target left" +
        Environment.NewLine + "D - change target right";
    }

    public void displayShotMSG(int hitPlayer, int playerTurn, int dmg)
    {
        displayText.text += Environment.NewLine + Environment.NewLine + "Player " + playerTurn + " shot Player " + hitPlayer + " for " + dmg + " damage";
    }

    public void addKillMSG(int hitPlayer)
    {
        displayText.text += Environment.NewLine + "Player " + hitPlayer + " has been killed";
    }

    public void displayReloadMSG(int playerTurn, int bullets)
    {
        displayText.text = "Player " + playerTurn + " reloaded " + bullets + " bullets";
    }
}
