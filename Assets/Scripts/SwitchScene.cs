using UnityEngine;

public class SwitchScene : MonoBehaviour
{
    private SceneController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

    //特定のキーが押下された場合、シーン遷移処理を呼び出す
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)
            || Input.GetKeyDown(KeyCode.A)
            || Input.GetKeyDown(KeyCode.S)
            || Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown(KeyCode.KeypadEnter)
            || Input.GetKeyDown(KeyCode.Mouse0))
        {
            sceneController.SwitchSceneNext();
        }
    }
}
