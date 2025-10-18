using UnityEngine;
using TMPro;

public class TextBoxes : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text displayText;

    public GameController game;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void onPlayerTurn()
    {
        displayText.text = game.roundOrder[game.nextOrder] + "'s turn";
    }
    void onShoot(int playerHit, int playerShooter)
    {

    }

}
