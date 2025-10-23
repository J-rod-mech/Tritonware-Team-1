using Unity.VisualScripting;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int hp;

    public int num;
    public GameObject gameMod;
    public GameController game;

    // n is the player num, from 1-4
    void Start()
    {
        hp = 3;
        gameMod = GameObject.Find("GameMod");
        game = gameMod.GetComponent<GameController>();
        if (this.gameObject.name == "Player1")
        {
            num = 1;
        }
        else if (this.gameObject.name == "Player2")
        {
            num = 2;
        }
        else if (this.gameObject.name == "Player3")
        {
            num = 3;
        }
        else if (this.gameObject.name == "Player4")
        {
            num = 4;
        }
    }

    // hit function to trigger effects
    public void GetHit()
    {
        if (hp <= 0)
        {
            Die();
        }
    }

    // death function to trigger effects
    void Die()
    {
        if (num == 1)
        {
            game.player1Sprite.enabled = false;
        }
        else if (num == 2)
        {
            game.player2Sprite.enabled = false;
        }
        else if (num == 3)
        {   
            game.player3Sprite.enabled = false;
        }
        else if (num == 4)
        {
            game.player4Sprite.enabled = false;
        }
    }
}
