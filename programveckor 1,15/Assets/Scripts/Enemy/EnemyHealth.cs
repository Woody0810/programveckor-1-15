﻿using System;
using Health_Scripts;
using UnityEngine;

namespace Enemy
{
	public class EnemyHealth : MonoBehaviour, IHealth
	{
		
		[field: SerializeField] public float MaxHealth { get; set; }
		public float CurrentHealth { get; set; }

		public event Action<float> OnHealthChanged;
		public event Action OnDeath;


		private void Start()
		{
			CurrentHealth = MaxHealth;
		}

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
	}
}
