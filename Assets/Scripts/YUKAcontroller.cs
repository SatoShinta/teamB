using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class YUKAcontroller : MonoBehaviour
{
    [SerializeField, Header("•Ï‰»Œã‚ÌŒ©‚½–Ú")] Sprite[] newSprite;
    public bool playerInHole;
    public int counter;


    public void OnTriggerExit2D(Collider2D collision)
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
                    counter = 1;
                    playerInHole = true;
                }
            }
        }
    }
}
