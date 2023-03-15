using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public Sprite[] sprites ;
    private int spritesCounter;
    void Start()
    {
        spritesCounter = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject); 
        setDamageToHouse();
    }

    private void setDamageToHouse()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(spritesCounter < sprites.Length)
        {
            spriteRenderer.sprite = sprites[spritesCounter];
            spritesCounter++;
        } else {
            Destroy(this.gameObject);
        }
    }
}
