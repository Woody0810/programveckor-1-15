using System.Collections;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int health = 100;  
    public int armor = 10;    
    public bool isDodging = false;  
    public float dodgeDuration = 1f;  
    private bool isInvincible = false;  

    public void ReceiveDamage(int damage)
    {
        if (isDodging || isInvincible)
        {

            return;
        }


        int effectiveDamage = Mathf.Max(damage - armor, 0);
        health -= effectiveDamage;

        if (health > 0)
        {
            return;
        }
        health = 0;
        Die();
    }

    private void Die()
    {
        Debug.Log("Character is dead.");
        
    }
    public void StartDodge()
    {
        if (isDodging) return;  

        StartCoroutine(DodgeCoroutine());
    }
    private IEnumerator DodgeCoroutine()
    {
        isDodging = true;
        isInvincible = true;
        Debug.Log("Dodging started!");

        yield return new WaitForSeconds(dodgeDuration);

        isDodging = false;
        isInvincible = false;
        Debug.Log("Dodging ended!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            ReceiveDamage(20);  
        }
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  
        {
            StartDodge();
        }
    }
}
