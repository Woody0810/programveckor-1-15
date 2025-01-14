using Enemy;
using Enemy.Base;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class AttackMele : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                Debug.Log("Amount of enemies: " + enemiesToDamage.Length);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().Takedamage(damage);
                    Debug.Log("pow enemy");
                }

                timeBtwAttack = startTimeBtwAttack; // Reset time between attacks after attack is executed
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime; // Decrement timeBtwAttack with time
        }
    }
}