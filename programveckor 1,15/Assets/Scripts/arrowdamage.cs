using System;
using Enemy;
using Health_Scripts;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

public class damage : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public Bow Bow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var eHealth = collision.gameObject.GetComponent<EnemyHealth>();
            eHealth.TakeDamage(10);
        }

        StartCoroutine(Returnarrow());
    }

    public IEnumerator Returnarrow()
    {
        yield return new WaitForSeconds(7);
        Bow.GetComponentInChildren<Quiver>().IncreaseArrows();
    }
}
