using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject gameController;
    private GameController controller;

    private void Start()
    {
        controller = gameController.GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player_laser")
        {
            Destroy(collision.gameObject);
            controller.score = controller.score + 100;
            Animator explosionAnimation = gameObject.GetComponent<Animator>();
            explosionAnimation.SetBool("isTriggered", true);
        }
    }
}
