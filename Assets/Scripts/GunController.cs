using System;
using System.ComponentModel;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject gameMod;
    public GameController game;
    private int[] magazine;
    public int ammo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        magazine = new int[6];
        ammo = 0;
        gameMod = GameObject.Find("GameMod");
        game = gameMod.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Modifies target player's hp based on bullet type fired
    public void Shoot(int hitPlayer, int playerTurn)
    {
        CharacterStats player = game.getStats(hitPlayer);
        player.hp += magazine[ammo - 1];
        player.GetHit();
        Debug.Log("Player " + playerTurn + " shot Player " + hitPlayer + " for " + (-magazine[ammo - 1]) + " damage");
        magazine[ammo - 1] = 0;
        ammo--;
        if (hitPlayer != playerTurn)
        {
            game.nextOrder++;
        }
        if (player.hp > 0)
        {
            game.reorderRound(hitPlayer);
        }
        else
        {
            game.playersStatus[hitPlayer - 1] = false;
            game.reorderRound(0);
            Debug.Log("Player " + hitPlayer + " has been killed");
        }
    }
    
    public void Reload(int playerTurn)
    {
        int hit = -1;
        int doublehit = -2;
        int heal = 1;
        int blank = 0;
        Debug.Log("Player " + playerTurn + " reloaded " + (6 - ammo) + " bullets");
        String reloadOrder = "chamber < ";
        for (int i = 5; i >= ammo; i--)
        {
            int bulletmod = UnityEngine.Random.Range(0, 100);
            if (bulletmod <= 39)
            {
                magazine[i] = hit;
            }
            else if (bulletmod <= 69)
            {
                magazine[i] = heal;
            }
            else if (bulletmod <= 94)
            {
                magazine[i] = blank;
            }
            else if (bulletmod <= 99)
            {
                magazine[i] = doublehit;
            }
            switch (magazine[i])
            {
                case -1:
                    reloadOrder += "hit";
                    break;
                case -2:
                    reloadOrder += "doublehit";
                    break;
                case 1:
                    reloadOrder += "heal";
                    break;
                case 0:
                    reloadOrder += "blank";
                    break;
            }
            if (i > ammo)
            {
                reloadOrder += ", ";
            }
        }
        if (playerTurn == 1)
        {
            Debug.Log(reloadOrder);
        }
        ammo = 6;
        game.nextOrder++;
    }
}
