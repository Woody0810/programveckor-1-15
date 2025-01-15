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
        SceneManager.LoadScene("SampleScene Adrian");
    }

    public void gotosettings()
    {
        SceneManager.LoadScene("settings");
    }

    public void gotomainmeny()
    {
        SceneManager.LoadScene("Main meny");

    }

    public void gotoAdrianTilemap()
    {
        SceneManager.LoadScene("Adrian Tilemap Test");
    }
}


