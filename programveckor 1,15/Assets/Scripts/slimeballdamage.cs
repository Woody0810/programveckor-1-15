using Enemy;
using Health_Scripts;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeballdamage : MonoBehaviour
{
    public PlayerHealth PlayerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth.TakeDamage(10);
        Destroy(gameObject);
    }


}
