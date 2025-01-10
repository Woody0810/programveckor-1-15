using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vinefinder : MonoBehaviour
{
    [SerializeField]
    private climb player;
    // Start is called before the first frame update
    private void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<vine>())
        {
            player.ClimbingAllowed = true;
        }

        if (collision.GetComponent<vine>())
        {
            player.ClimbingAllowed = false;
        }
    }
}
