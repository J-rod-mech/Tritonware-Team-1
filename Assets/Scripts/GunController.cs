using System.ComponentModel;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameController game;
    private int[] magazine;
    private int ammo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        magazine = new int[6];
        ammo = 0;
        game = GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Modifies target player's hp based on bullet type fired
    public void Shoot(int hitPlayer, int bullet)
    {
        CharacterStats player = game.getStats(hitPlayer);
        player.hp += bullet;
        player.GetHit();
        game.nextOrder++;
        if (player.hp > 0)
        {
            game.reorderRound(hitPlayer);
        }
        ammo--;
    }
    
    void Reload()
    {
        int hit = -1;
        int doublehit = -2;
        int heal = 1;
        int miss = 0;
        int bulletmod = Random.Range(0, 99);
        for (int i = ammo; i <= 5; i++)
        {
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
                magazine[i] = miss;
            }
            else if (bulletmod <= 99)
            {
                magazine[i] = doublehit;
            }
        }
        ammo = 6;
    }
}
