using Unity.VisualScripting;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int hp;

    public int num;

    // n is the player num, from 1-4
    void Start()
    {
        hp = 5;
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
        
    }
}
