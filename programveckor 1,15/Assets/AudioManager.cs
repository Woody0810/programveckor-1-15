using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio score")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [HeaderAttribute("Audioclip")]
    public AudioClip Backround1;
    public AudioClip Backround2;
    public AudioClip Door;
    public AudioClip heartbeat;
    public AudioClip Bigpunch;
    public AudioClip Slash;
    public AudioClip mainmenu;

    public bool isInCurrentScene;
    public string lastScene;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (lastScene == currentScene.name) return;

        if (currentScene.name == "Adrian Tilemap Test" || currentScene.name == "settings") 
{        musicSource.clip = Backround1;
            musicSource.Play();
            audioManager.PlaySFX(audioManager.heartbeat);
            Debug.Log("Adrian");
            lastScene = currentScene.name;
        }    
        else if (currentScene.name == "main meny")
        {
            musicSource.clip = mainmenu;
            musicSource.Play();
            Debug.Log("Main");
            lastScene = currentScene.name;
        }
        else if (currentScene.name == "Alberbana")
        {
            musicSource.clip = Backround2;
            musicSource.Play();
            audioManager.PlaySFX(audioManager.heartbeat);
            Debug.Log("Alber");
            lastScene = currentScene.name;
        }
        
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

