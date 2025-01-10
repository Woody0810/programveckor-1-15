using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void gotogame()
    {
        SceneManager.LoadScene("main game");
    }

    public void gotosettings()
    {
        SceneManager.LoadScene("settings");
    }

    public void gotomainmeny()
    {
        SceneManager.LoadScene("Main meny");
    }
}

