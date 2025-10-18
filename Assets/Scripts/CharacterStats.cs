using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int hp;

    // n is the player num, from 1-4
    void Start()
    {
        hp = 5;
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
