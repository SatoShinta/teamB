using UnityEngine;

public class SwitchScene : MonoBehaviour
{
    private SceneController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

    //����̃L�[���������ꂽ�ꍇ�A�V�[���J�ڏ������Ăяo��
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
