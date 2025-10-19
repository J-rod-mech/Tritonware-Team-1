using UnityEngine;

public class StartandStopScreen : MonoBehaviour
{
    private Texture2D startScreen;

    private Renderer targetRenderer;
    private Texture2D gameOverScreen;

    private Texture2D winScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRenderer.material.mainTexture = startScreen;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (isGameOverScreen() == True)
        {
            targetRenderer.material.mainTexture = gameOverScreen;
        }
        */
    }
}
