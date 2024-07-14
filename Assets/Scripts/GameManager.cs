using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ImageWindow;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI characterMessage;


    void Start()
    {
        text.text = "";

        ImageWindow.gameObject.SetActive(false);
        characterMessage.text = "";
    }
}
