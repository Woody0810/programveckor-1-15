using System;
using Health_Scripts;
using Player;
using UnityEngine;

namespace Enemy
{
	public class EnemyHealth : MonoBehaviour, IHealth
	{
		
		[field: SerializeField] public float MaxHealth { get; set; }
		public float CurrentHealth { get; set; }

		/// <summary>
		/// Event that gets called when the health changes, takes in the current health as a paramater
		/// </summary>
		public event Action<float> OnHealthChanged;

		/// <summary>
		/// Event that gets called when the objects health is less than or equal to 0
		/// </summary>
		public event Action OnDeath;

		private void OnEnable()
		{
			OnDeath += Death;
		}

		private void OnDisable()
		{
			OnDeath -= Death;
		}

		private void Start()
		{
			CurrentHealth = MaxHealth;
		}

		/// <summary>
		/// Takes damage
		/// </summary>
		/// <param name="amount">The amount of damage</param>
		public void TakeDamage(float amount)
		{
			CurrentHealth -= amount;

			if (CurrentHealth <= 0)
			{
				CurrentHealth = 0;
				OnDeath?.Invoke();
			}

			OnHealthChanged?.Invoke(CurrentHealth);
		}

		public void HealHealth(float amount)
		{
		}

		public void Takedamage(int damage)
		{
			CurrentHealth -= damage;
			Debug.Log("damage takenshshhshshsh " + CurrentHealth);

            if (CurrentHealth <= 0)
            {
				Destroy(gameObject);
			}
        }

		private void Death()
		{
			PlayerManager.Instance.PlayerHealth.HealHealth(2.5f);
			Destroy(gameObject);
		}
	}
}
