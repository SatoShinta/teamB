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

    //�e�L�X�g�R���g���[���[�ɕ\������e�L�X�g�ƃL�����摜���Z�b�g���A�`�揈�����Ăяo��
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
