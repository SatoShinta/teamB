using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextWindowController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Sprite defaultImage;
    [SerializeField] private float delayDuration;

    private Image _image;

    private List<string> _textList;
    private WaitForSeconds _daray;

    void Start()
    {
        GameObject characterImage = GameObject.FindGameObjectWithTag("MiniCharaImage");
        _image = characterImage.GetComponent<Image>();

        _daray = new WaitForSeconds(delayDuration);
    }

    public void SetTextList(List<string> textList)
    {
        _textList = textList;
    }

    public void SetImage(Sprite image)
    {
        _image.sprite = image;
    }

    public IEnumerator DrawTextWindow()
    {
        for (int i = 0; i < _textList.Count; i++)
        {
            var textLength = _textList[i].Length;

            _text.text = _textList[i];
            _text.maxVisibleCharacters = 0;

            for (var j = 0; j < textLength; j++)
            {
                _text.maxVisibleCharacters = j;

                yield return _daray;
            }

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.anyKeyDown);
        }

        _text.text = "";
        _image.sprite = defaultImage;

        StopCoroutine(DrawTextWindow());
    }
}
