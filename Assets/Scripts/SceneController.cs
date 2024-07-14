using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    public void SwitchSceneNext()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
