using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class YUKAcontroller : MonoBehaviour
{
    [SerializeField, Header("•Ï‰»Œã‚ÌŒ©‚½–Ú")] Sprite[] newSprite;
    public Sprite nomal;
    public bool playerInHole;
    public int counter;
    PlayerState playerState;
    SpriteRenderer henkouSprite;



    private void Start()
    {
        GameObject obj = GameObject.Find("Player");
        playerState = obj.GetComponent<PlayerState>();
        henkouSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
      if(playerState.gameOver == true)
        {
            henkouSprite.sprite = nomal;
            counter = 0;
            playerInHole = false;
        }   
    }


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
