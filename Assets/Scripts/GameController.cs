using System.Linq.Expressions;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // tracks whether players at indices i - 1 are alive (true) or dead (false)
    public bool[] playersStatus;

    // 4-size array that stores a player number at each index
    public int[] roundOrder;

    // tracks position in the roundOrder (0-3), indicating whose turn is next
    public int nextOrder;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public CharacterStats pStats1;
    public CharacterStats pStats2;
    public CharacterStats pStats3;
    public CharacterStats pStats4;

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

    // Update is called once per frame
    void Update()
    {

    }

    public void runGame()
    {
        // function runs once per turn
        while (true) {
            
        }
    }

    // startPlayer is a num from 1-4
    public void startRound(int startPlayer)
    {
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
    }

    // change ordering for when a player is shot
    // precondition: player has not moved
    public void reorderRound(int nextPlayer)
    {   
        for (int i = 3; i > nextOrder; i--)
        {
            if (roundOrder[i] == nextPlayer)
            {
                roundOrder[i] = roundOrder[i - 1];
                roundOrder[i - 1] = nextPlayer;
            }
        }
    }

    // Modifies target player's hp based on bullet type fired
    public void ShootAt(int hitPlayer, int bullet)
    {
        CharacterStats player = getStats(hitPlayer);
        player.hp += bullet;
        player.GetHit();
        nextOrder++;
        reorderRound(hitPlayer);
    }
}
