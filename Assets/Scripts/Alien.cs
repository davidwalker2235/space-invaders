using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject gameController;
    private GameController controller;
    public AudioSource alienZappedSound; // Reference to the AudioSource component

    private void Start()
    {
        controller = gameController.GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player_laser")
        {
            Destroy(collision.gameObject);
            //alienZappedSound.Play(); // BUG this line cause the alient not to be killed!
            System.Diagnostics.Debug.WriteLine("Zapping aliens");
            controller.score = controller.score + 100;
            Animator explosionAnimation = gameObject.GetComponent<Animator>();
            explosionAnimation.SetBool("isTriggered", true);
        }
    }
}
