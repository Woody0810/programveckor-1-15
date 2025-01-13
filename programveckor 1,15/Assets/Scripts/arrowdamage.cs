using Enemy;
using Health_Scripts;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public EnemyHealth EnemyHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth.DealDamage(10);
        Destroy(gameObject);
    }


}
