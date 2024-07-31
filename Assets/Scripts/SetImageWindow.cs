using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetImageWindow : MonoBehaviour
{
    [SerializeField] private Sprite settingImage;
    [SerializeField] private string settingMessage;

    [SerializeField] private GameObject imageWindow;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _message;

    public void SetImage()
    {
        _image.sprite = settingImage;
        _message.text = settingMessage;
        imageWindow.SetActive(true);
    }
}
