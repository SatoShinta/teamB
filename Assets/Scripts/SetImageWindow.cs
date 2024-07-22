using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetImageWindow : MonoBehaviour
{
    [SerializeField] private Sprite settingImage;
    [SerializeField] private string settingMessage;

    private GameObject imageWindow;
    private Image _image;
    private TextMeshProUGUI _message;

    void Start()
    {
        imageWindow = GameObject.FindGameObjectWithTag("ImageWindow");
        _image = GameObject.FindGameObjectWithTag("CharaImage").GetComponent<Image>();
        _message = GameObject.FindGameObjectWithTag("CharaMessage").GetComponent<TextMeshProUGUI>();
    }

    public void SetImage()
    {
        _image.sprite = settingImage;
        _message.text = settingMessage;
        imageWindow.SetActive(true);
    }
}
