using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject gameController;
    private GameController controller;

    public GameObject scoreNumber;
    public GameObject gameOverText;
    public GameObject lifes;
    public GameObject youWinText;
    private TextMeshProUGUI lifesText;
    private TextMeshProUGUI score;

    void Start()
    {
        controller = gameController.GetComponent<GameController>();
        lifesText = lifes.GetComponent<TextMeshProUGUI>();
        score = scoreNumber.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.isPlayerAlive)
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }
        if (controller.isWinner && controller.isPlayerAlive)
        {
            youWinText.SetActive(true);
            Time.timeScale = 0;
        }
        lifesText.SetText(controller.lifes.ToString());
        score.SetText(controller.score.ToString());
    }
}
