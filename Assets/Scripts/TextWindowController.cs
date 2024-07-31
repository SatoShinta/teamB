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

    private WaitForSeconds _deray;
    private WaitUntil waitUserAction;

    void Start()
    {
        _image = GameObject.FindGameObjectWithTag("MiniCharaImage").GetComponent<Image>();

        _deray = new WaitForSeconds(delayDuration);
        waitUserAction = new WaitUntil(() => Input.anyKeyDown);
    }

    public void SetTextList(List<string> textList)
    {
        _textList = textList;
    }

    public void SetImage(Sprite image)
    {
        _image.sprite = image;
    }

    //�e�L�X�g��1�������`�悵�A�Ō�Ƀe�L�X�g�ƃL�����摜��������
    public IEnumerator DrawTextWindow()
    {
        for (int i = 0; i < _textList.Count; i++)
        {
            _text.text = _textList[i].Replace("\\r", "\r").Replace("\\n", "\n");
            _text.maxVisibleCharacters = 0;

            for (var j = 0; j < _textList[i].Length; j++)
            {
                _text.maxVisibleCharacters = j;

                yield return _deray;
            }

            yield return waitUserAction;
        }

        _text.text = "";
        _image.sprite = defaultImage;

        StopCoroutine(DrawTextWindow());
    }
}
