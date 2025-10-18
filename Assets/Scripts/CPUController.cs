using UnityEngine;

public class CPUController : MonoBehaviour
{
    public GameController game;
    public GunController gun;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = GetComponent<GameController>();
        gun = GetComponent<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // makes an action
    public void Act()
    {
        int choice = Random.Range(0, 2);
        if (choice == 1)
        {
            
        }
    }
    
    public void CPUShoot()
    {
        int[] targets = new int[3];
        int numTargets = 0;
        for (int i = 0; i < 4; i++)
        {
            if (game.playersStatus[i])
            {
                targets[numTargets] =
            }
        }
    }
}
