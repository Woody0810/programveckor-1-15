﻿using System;
using System.Collections.Generic;
using Effects.Interfaces;
using Health_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
	
	[Serializable]
	public class PlayerHealth : MonoBehaviour, IHealth
	{
        [field: SerializeField] public float MaxHealth { get; set; }
		public float CurrentHealth { get; set; }
		public Queue<Coroutine> Effects { get; set; }

		public event Action<float> OnHealthChanged;
		public event Action OnDeath;

		public bool IsDamagable { get; set; } = true;
		public bool IsEffectable { get; set; }

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

		public void DealDamage(float amount)
		{
			if (!IsDamagable) return;

			CurrentHealth -= amount;

			if (CurrentHealth <= 0)
			{
				Death();
			}

			OnHealthChanged?.Invoke(CurrentHealth);
		}

		public void HealHealth(float amount)
		{
			CurrentHealth += amount;

			CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

			OnHealthChanged?.Invoke(CurrentHealth);
		}

		private void Death()
		{
			Debug.Log("Player Died :(");
			Destroy(gameObject);
		}
	}
}
