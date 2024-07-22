using System.Collections.Generic;
using UnityEngine;

public class SetText : MonoBehaviour
{
    [SerializeField] private List<string> textList;
    [SerializeField] private Sprite settingImage;

    private TextWindowController textController;

    private bool IsShowed = false;

    void Start()
    {
        textController = FindObjectOfType<TextWindowController>();
    }

    //テキストコントローラーに表示するテキストとキャラ画像をセットし、描画処理を呼び出す
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !IsShowed)
        {
            IsShowed = true;

            textController.SetTextList(textList);
            textController.SetImage(settingImage);

            StartCoroutine(textController.DrawTextWindow());
        }
    }
}
