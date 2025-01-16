using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OppendoornewPlace : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Albert Bana");

            audioManager.PlaySFX(audioManager.Door);
        }       

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Adrian Tilemap Test");

            audioManager.PlaySFX(audioManager.Door);
        }
    }
}
