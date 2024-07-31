using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private List<string> defaultText;

    [SerializeField] private GameObject imageWindow;
    [SerializeField] private TextMeshProUGUI characterMessage;

    private TextWindowController textController;

    void Start()
    {
        textController = FindObjectOfType<TextWindowController>();

        if (defaultText != null)
        {
            textController.SetTextList(defaultText);
            StartCoroutine(textController.DrawTextWindow());
        }
        else _text.text = "";

        imageWindow.gameObject.SetActive(false);
        characterMessage.text = "";
    }
}
