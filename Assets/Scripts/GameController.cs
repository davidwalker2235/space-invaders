using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class GameController : MonoBehaviour
{
    public bool isPlayerAlive;
    public int lifes;
    public int score;
    public bool isWinner;

    //public AudioSource gameOverSound; // Reference to the AudioSource component
    //public AudioSource winGameSound; // Reference to the AudioSource component
    void Awake()
    {
        lifes = 3;
        isPlayerAlive = true;
        score = 0;
    }

    public void WinGame()
    {
        isWinner = true;
        //winGameSound.Play();
        System.Diagnostics.Debug.WriteLine("This is a Win Game  message.");
    }


    public void LoseGame()
    {
        isWinner = false;
        //gameOverSound.Play();
        System.Diagnostics.Debug.WriteLine("This is a Lose Game  message.");

    }
}
