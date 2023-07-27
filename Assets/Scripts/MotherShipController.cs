using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipController : MonoBehaviour
{
    public float speed = 5f;
    public float startPositionX = -10f;
    public float endPositionX = 10f;

    private bool movingRight = true;

    private AudioSource motherShip_sound;

    private void Start()
    {
        motherShip_sound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        MoveMotherShip();
    }

    private void MoveMotherShip()
    {
        float step = speed * Time.deltaTime;

        // Move the Mother Ship horizontally
        if (movingRight)
        {
            transform.Translate(Vector3.right * step);
            if (transform.position.x >= endPositionX)
            {
                movingRight = false;
                PlayBleepingSound();
            }
        }
        else
        {
            transform.Translate(Vector3.left * step);
            if (transform.position.x <= startPositionX)
            {
                movingRight = true;
                PlayBleepingSound();
            }
        }
    }
    private void PlayBleepingSound()
    {
        if (motherShip_sound != null && motherShip_sound.clip != null)
        {
            motherShip_sound.Play();
        }
    }

    /*
     * Commenting out this to make it easier to test explosions on Mothership
     * private IEnumerator SpawnMotherShip()
    {
        while (true)
        {
            // Code to instantiate the Mother Ship here
            // For simplicity, I'll just deactivate and reactivate the GameObject

            gameObject.SetActive(false);
            yield return new WaitForSeconds(5f);
            gameObject.SetActive(true);
        }
    }
    */
}
