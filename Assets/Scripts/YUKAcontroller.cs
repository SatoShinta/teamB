using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YUKAcontroller : MonoBehaviour
{
    [SerializeField, Header("変化後の見た目")] Sprite[] newSprite;
    int counter = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SpriteRenderer yukaSpriteRenderer = GetComponent<SpriteRenderer>();

            if(yukaSpriteRenderer != null && newSprite != null)
            {
                yukaSpriteRenderer.sprite = newSprite[counter];
                counter++;
                if(counter == newSprite.Length)
                {
                    counter = 2;
                }
            }
        }
    }
}
