using System.Collections.Generic;
using UnityEngine;

public class SetText : MonoBehaviour
{
    [SerializeField] private List<string> textList;
    [SerializeField] private Sprite settingImage;

    private TextWindowController textController;

    void Start()
    {
        textController = FindObjectOfType<TextWindowController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textController.SetTextList(textList);
            textController.SetImage(settingImage);

            StartCoroutine(textController.DrawTextWindow());
        }
    }
}
