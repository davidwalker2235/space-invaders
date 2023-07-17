using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject controller;

    private GameController gameController;

    public AudioSource laserSound; // Reference to the AudioSource component

    public AudioSource gameOverSound; // Reference to the AudioSource component
    void Start()
    {
        gameController = controller.GetComponent<GameController>();
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        };
    }

    void CalculateMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontal, 0, 0) * speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6f, 6f), -4, 0);
    }

    void FireLaser()
    {

        Instantiate(laserPrefab, transform.position + new Vector3(0, 0f, 0), Quaternion.identity);
        laserSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag == "alien_laser" || collision.tag == "alien" && gameController.lifes > 0)
        {
            gameController.lifes--;
        }
        else if (gameController.lifes == 0)
        {
            gameController.isPlayerAlive = false;
            gameOverSound.Play();
            Destroy(this.gameObject);
        }
    }
}
