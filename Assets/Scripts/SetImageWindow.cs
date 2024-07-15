using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetImageWindow : MonoBehaviour
{
    [SerializeField] private Sprite settingImage;
    [SerializeField] private string settingMessage;

    private GameObject imageWindow;
    private Image _image;
    private TextMeshProUGUI _meaaage;

    void Start()
    {
        imageWindow = GameObject.FindGameObjectWithTag("CharaImage");
        _image = imageWindow.GetComponent<Image>();

        GameObject characterMessage = GameObject.FindGameObjectWithTag("CharaMessage");
        _meaaage = characterMessage.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _image.sprite = settingImage;
            _meaaage.text = settingMessage;
            imageWindow.SetActive(true);
        }
    }
}
