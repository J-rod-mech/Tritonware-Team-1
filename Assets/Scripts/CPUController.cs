using UnityEngine;

public class CPUController : MonoBehaviour
{
    public GameObject gameMod;
    public GameController game;
    public GunController gun;
    public GameObject text;
    public TextBoxes textbox;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameMod = GameObject.Find("GameMod");
        game = gameMod.GetComponent<GameController>();
        gun = gameMod.GetComponent<GunController>();
        text = GameObject.Find("DialogueText");
        textbox = text.GetComponent<TextBoxes>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // makes an action
    public void Act(int self)
    {
        int choice = Random.Range(0, 2);
        if (gun.ammo == 6)
        {
            CPUShoot(self);
        }
        else if (gun.ammo <= 0 /*|| choice == 0*/)
        {
            gun.Reload(self);
        }
        else /*if (choice == 1)*/
        {
            CPUShoot(self);
        }
    }
    
    public void CPUShoot(int self)
    {
        int[] targets = new int[4];
        int numTargets = 0;
        for (int i = 0; i < 4; i++)
        {
            if (game.playersStatus[i])
            {
                targets[numTargets++] = i + 1;
            }
        }

        int target = Random.Range(0, numTargets);
        gun.Shoot(targets[target], self);
    }
}
