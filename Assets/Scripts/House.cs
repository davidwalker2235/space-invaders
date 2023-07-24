using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class House : MonoBehaviour
{
    public Sprite[] sprites ;
    private int spritesCounter;
    public AudioSource house_damage; // Reference to the AudioSource component

    void Start()
    {
        spritesCounter = 0;

        //house_damage = AudioSource.GetComponent<AudioSource>();
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
            System.Diagnostics.Debug.WriteLine("This is a Damage House  message.");
            spritesCounter++;

            try
            {
                // Your code block goes here
                house_damage.Play();
            }
            catch (ArgumentNullException ex)
            {
                // Handle the ArgumentNullException here
                System.Diagnostics.Debug.WriteLine("ArgumentNullException caught: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions, if needed
                System.Diagnostics.Debug.WriteLine("Exception caught: " + ex.Message);
            }



        }
        else {
            Destroy(this.gameObject);
        }
    }
}
