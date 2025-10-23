using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string sceneToLoad = "FPVScene";
    public string endScene = "EndScene";

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {

        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {

            Debug.LogError("ERROR: 'Scene to Load' is not set in the Inspector!");
        }
    }
    public void endGameScene()
    {
        SceneManager.LoadScene(endScene);
    }

}