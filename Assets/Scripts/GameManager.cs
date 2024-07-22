using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ImageWindow;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI characterMessage;

    void Start()
    {
        _text.text = "";

        ImageWindow.gameObject.SetActive(false);
        characterMessage.text = "";
    }
}
