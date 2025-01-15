using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audio : MonoBehaviour
{
    [Header("Audio score")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource Source;

    [HeaderAttribute("Audioclip")]
    public AudioClip Backround1;
    public AudioClip Backround2;
    public AudioClip Door;
    public AudioClip heartbeat;
    public AudioClip Bigpunch;
    public AudioClip Slash;
    public AudioClip mainmenu;

    public bool isInCurrentScene;

    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (isInCurrentScene) return;
        else
        {
            isInCurrentScene = false;
        }

        if (currentScene.name == "Adrian Tilemap Test" && !isInCurrentScene) 
{        musicSource.clip = Backround1;
            musicSource.Play();
            isInCurrentScene = true;
            Debug.Log("Adrian");
        }    
        else if (currentScene.name == "Main meny" && !isInCurrentScene)
        {
            musicSource.clip = mainmenu;
            musicSource.Play();
            isInCurrentScene = true;
            Debug.Log("Main");
        }
        else if (currentScene.name == "Alberbana" && !isInCurrentScene&& !isInCurrentScene)
        {
            musicSource.clip = Backround2;
            musicSource.Play();
            isInCurrentScene = true;
            Debug.Log("Alber");
        }
    }
    
}

