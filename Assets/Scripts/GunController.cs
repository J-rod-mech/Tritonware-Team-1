using System;
using System.ComponentModel;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject gameMod;
    public GameController game;
    public GameObject text;
    public TextBoxes textbox;
    private int[] magazine;
    public int ammo;
    public GameObject sound;
    public AudioPlayer audioPlayer;

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public GameObject b6;
    public SpriteRenderer bullet1;
    public SpriteRenderer bullet2;
    public SpriteRenderer bullet3;
    public SpriteRenderer bullet4;
    public SpriteRenderer bullet5;
    public SpriteRenderer bullet6;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        magazine = new int[6];
        ammo = 0;
        gameMod = GameObject.Find("GameMod");
        game = gameMod.GetComponent<GameController>();
        text = GameObject.Find("DialogueText");
        textbox = text.GetComponent<TextBoxes>();
        sound = GameObject.Find("Sound");
        audioPlayer = sound.GetComponent<AudioPlayer>();
        b1 = GameObject.Find("Bullet1");
        b2 = GameObject.Find("Bullet2");
        b3 = GameObject.Find("Bullet3");
        b4 = GameObject.Find("Bullet4");
        b5 = GameObject.Find("Bullet5");
        b6 = GameObject.Find("Bullet6");
        bullet1 = b1.GetComponent<SpriteRenderer>();
        bullet2 = b2.GetComponent<SpriteRenderer>();
        bullet3 = b3.GetComponent<SpriteRenderer>();
        bullet4 = b4.GetComponent<SpriteRenderer>();
        bullet5 = b5.GetComponent<SpriteRenderer>();
        bullet6 = b6.GetComponent<SpriteRenderer>();
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
        if (magazine[ammo - 1] == -1)
        {
            audioPlayer.SingleshotAudio();
        }
        else if (magazine[ammo - 1] == -2)
        {
            audioPlayer.DoubleshotAudio();
        }
        else if (magazine[ammo - 1] == 1)
        {
            audioPlayer.HealAudio();
        }
        else if (magazine[ammo - 1] == 0)
        {
            audioPlayer.MisfireAudio();
        }

        player.GetHit();
        textbox.displayShotMSG(hitPlayer, playerTurn, -magazine[ammo - 1]);
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
            game.reorderRound(-1);
            textbox.addKillMSG(hitPlayer);
        }
        textbox.interrupt = true;
        if (ammo == 0)
        {
            bullet1.enabled = false;
        }
        else if (ammo == 1)
        {
            bullet2.enabled = false;
        }
        else if (ammo == 2)
        {
            bullet3.enabled = false;
        }
        else if (ammo == 3)
        {
            bullet4.enabled = false;
        }
        else if (ammo == 4)
        {
            bullet5.enabled = false;
        }
        else if (ammo == 5)
        {
            bullet6.enabled = false;
        }
    }

    // Refill the gun's chamber to full then spin the barrel
    public void Reload(int playerTurn)
    {
        int hit = -1;
        int doublehit = -2;
        int heal = 1;
        int blank = 0;
        String reloadOrder = "< ";
        // refill bullets
        audioPlayer.ReloadAudio();
        for (int i = 5; i >= ammo; i--)
        {
            int bulletmod = UnityEngine.Random.Range(0, 100);
            if (bulletmod <= 39)
            {
                magazine[i] = hit;
            }
            else if (bulletmod <= 64)
            {
                magazine[i] = heal;
            }
            else if (bulletmod <= 89)
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
        bullet1.enabled = true;
        bullet2.enabled = true;
        bullet3.enabled = true;
        bullet4.enabled = true;
        bullet5.enabled = true;
        bullet6.enabled = true;

        // spin barrel to randomize position
        int startPos = UnityEngine.Random.Range(0, 6);
        int[] oldMag = new int[6];
        for (int i = 0; i < 6; i++)
        {
            oldMag[i] = magazine[i];
        }
        for (int i = 0; i < 6; i++)
        {
            magazine[i] = oldMag[(i + startPos) % 6];
        }
        if (playerTurn == 1)
        {
            Debug.Log(reloadOrder);
        }
        ammo = 6;
        textbox.displayReloadMSG(playerTurn);
        game.nextOrder++;
        textbox.interrupt = true;
    }
}
