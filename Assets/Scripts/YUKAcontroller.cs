using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class YUKAcontroller : MonoBehaviour
{
    [SerializeField, Header("•Ï‰»Œã‚ÌŒ©‚½–Ú")] Sprite[] newSprite;
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
