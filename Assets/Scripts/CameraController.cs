using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;

    void Start()
    {
        c1 = GameObject.Find("Player1Cam");
        c2 = GameObject.Find("Player2Cam");
        c3 = GameObject.Find("Player3Cam");
        c4 = GameObject.Find("Player4Cam");
        camera1 = c1.GetComponent<Camera>();
        camera2 = c2.GetComponent<Camera>();
        camera3 = c3.GetComponent<Camera>();
        camera4 = c4.GetComponent<Camera>();
    }
    public void FocusOnPlayer(int playerSelection)
    {

        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;

        switch (playerSelection)
        {
            case 1:
                camera1.enabled = true;
                break;
            case 2:
                camera2.enabled = true;
                break;
            case 3:
                camera3.enabled = true;
                break;
            case 4:
                camera4.enabled = true;
                break;
            default:
                Debug.LogWarning("Invalid player selection: " + playerSelection);
                break;
        }
    }

}
