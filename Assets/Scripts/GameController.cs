using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isPlayerAlive;
    public int lifes;
    public int score;
    public bool isWinner;
    void Awake()
    {
        lifes = 3;
        isPlayerAlive = true;
        score = 0;
    }

    public void WinGame()
    {
        isWinner = true;
    }
}
