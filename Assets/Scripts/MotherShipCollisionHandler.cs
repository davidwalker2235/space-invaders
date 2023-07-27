using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipCollisionHandler : MonoBehaviour
{
    public GameObject gameController;
    private GameController controller;
    public int scoreBonus = 100;
    public AudioSource explosion; // Reference to the AudioSource component
    // Start is called before the first frame update
    void Start()
    {
        controller = gameController.GetComponent<GameController>();
        explosion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Projectile"))
        if (collision.tag == "player_laser")
        {
            // Handle collision with the player's projectile here
            Destroy(collision.gameObject);
            explosion.Play();
            // For example, you can play an explosion effect, increase the score, etc.
            System.Diagnostics.Debug.WriteLine("Mother*****");
            controller.score = controller.score + 500;
            // Deactivate the projectile (optional)
            collision.gameObject.SetActive(false);

            // Increase the player's score (you need to have a score system)
            // For example, you can access the score system through a GameManager script
            // GameManager.Instance.IncreaseScore(scoreBonus);
        }
    }
}
