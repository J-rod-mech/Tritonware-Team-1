using System.Linq.Expressions;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using System.Threading;
using System;

public class GameController : MonoBehaviour
{
    // tracks whether players at indices i - 1 are alive (true) or dead (false)
    public bool[] playersStatus;

    // 4-size array that stores a player number at each index
    public int[] roundOrder;

    // tracks position in the roundOrder (0-3), indicating whose turn is next
    public int nextOrder;

    // starting player for each round
    public int startPlayer;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public CharacterStats pStats1;
    public CharacterStats pStats2;
    public CharacterStats pStats3;
    public CharacterStats pStats4;
    public SpriteRenderer player1Sprite;
    public SpriteRenderer player2Sprite;
    public SpriteRenderer player3Sprite;
    public SpriteRenderer player4Sprite;

    public CPUController cpu;

    public GunController gun;
    public GameObject text;
    public TextBoxes textbox;
    public SelectController select;
    public GameObject sound;
    public MusicPlayer musicPlayer;
    public bool playerTurnFinished = false;
    public GameObject hg;
    public SpriteRenderer handgun;

    void Start()
    {
        playersStatus = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            playersStatus[i] = true;
        }
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");
        pStats1 = player1.GetComponent<CharacterStats>();
        pStats2 = player2.GetComponent<CharacterStats>();
        pStats3 = player3.GetComponent<CharacterStats>();
        pStats4 = player4.GetComponent<CharacterStats>();
        player1Sprite = player1.GetComponent<SpriteRenderer>();
        player2Sprite = player2.GetComponent<SpriteRenderer>();
        player3Sprite = player3.GetComponent<SpriteRenderer>();
        player4Sprite = player4.GetComponent<SpriteRenderer>();
        text = GameObject.Find("DialogueText");
        textbox = text.GetComponent<TextBoxes>();
        cpu = GetComponent<CPUController>();
        gun = GetComponent<GunController>();
        select = GetComponent<SelectController>();
        sound = GameObject.Find("Sound");
        musicPlayer = sound.GetComponent<MusicPlayer>();
        hg = GameObject.Find("ShootingFPV");
        handgun = hg.GetComponent<SpriteRenderer>();
        StartCoroutine(runGame());
    }

    public CharacterStats getStats(int n)
    {
        if (n == 1)
        {
            return pStats1;
        }
        else if (n == 2)
        {
            return pStats2;
        }
        else if (n == 3)
        {
            return pStats3;
        }
        else if (n == 4)
        {
            return pStats4;
        }
        else
        {
            return null;
        }
    }

    // initialize game
    IEnumerator runGame()
    {
        musicPlayer.PlayAudio();
        startPlayer = UnityEngine.Random.Range(0, 4) + 1;
        startRound();
        while (true)
        {
            while (roundOrder[nextOrder] != 1)
            {
                yield return StartCoroutine(CPUAction());
            }

            if (playersStatus[2])
            {
                select.playerSelection = 3;
            }
            else if (playersStatus[1])
            {
                select.playerSelection = 2;
            }
            else if (playersStatus[3])
            {
                select.playerSelection = 4;
            }
            textbox.onPlayerTurn();
            handgun.enabled = true;
            yield return new WaitForSeconds(1f);
            textbox.displayActionList();
            Debug.Log("P1: " + getStats(1).hp + "HP|P2: " + getStats(2).hp + "HP|P3: " + getStats(3).hp + "HP|P4:" + getStats(4).hp + "HP");
            Debug.Log(gun.ammo + " bullets left");

            // Wait until the player finishes their turn
            while (nextOrder < 4 && roundOrder[nextOrder] == 1)
            {
                // delay during your turn
                if (textbox.interrupt)
                {
                    yield return new WaitForSeconds(1.5f);
                    textbox.interrupt = false;
                    if (roundOrder[nextOrder] == 1)
                    {
                        textbox.displayActionList();
                    }
                }
                yield return new WaitUntil(() => !textbox.interrupt);
            }

            yield return new WaitUntil(() => nextOrder >= 4 || roundOrder[nextOrder] != 1);
            yield return new WaitForSeconds(1.5f);
            handgun.enabled = false;

            while (nextOrder < 4 && roundOrder[nextOrder] != 0)
            {
                yield return StartCoroutine(CPUAction());
            }
            startRound();
        }
    }

    // Coroutine for CPU action
    IEnumerator CPUAction()
    {
        textbox.onPlayerTurn();
        yield return new WaitForSeconds(1f);
        cpu.Act(roundOrder[nextOrder]);
        yield return new WaitForSeconds(2f);
    }

    // startPlayer is a num from 1-4
    public void startRound()
    {
        Debug.Log("New Round!");
        // init round
        roundOrder = new int[4];
        nextOrder = 0;

        // loop around from startPlayer and add their turn ordering
        for (int i = 0; i < 4; i++)
        {
            int player = (startPlayer - 1 + i) % 4 + 1;
            if (playersStatus[player - 1])
            {
                roundOrder[nextOrder++] = player;
            }
        }

        nextOrder = 0;
        startPlayer = startPlayer % 4 + 1;
    }

    // change ordering for when a player is shot or dies
    // precondition: player has not moved
    public void reorderRound(int nextPlayer)
    {
        for (int i = 0; i < 4; i++)
        {
            if (roundOrder[i] != 0 && playersStatus[roundOrder[i] - 1] == false)
            {
                for (int j = i; j < 3; j++)
                {
                    roundOrder[j] = roundOrder[j + 1];
                }
                roundOrder[3] = 0;
            }
        }
        for (int i = 3; i > nextOrder; i--)
        {
            if (roundOrder[i] == nextPlayer)
            {
                roundOrder[i] = roundOrder[i - 1];
                roundOrder[i - 1] = nextPlayer;
            }
        }
    }
}
