using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToAdrian : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown("E"))
        {
            SceneManager.LoadScene("Adrian Tilemap Test");
        }
    }

}
