using System;
using System.Collections.Generic;
using Effects.Interfaces;
using Health_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
	
	[Serializable]
	public class PlayerHealth : MonoBehaviour, IHealth, IEffectable
	{
        [field: SerializeField] public float MaxHealth { get; set; }
		public float CurrentHealth { get; set; }
		public Queue<Coroutine> Effects { get; set; }

		public event Action<float> OnHealthChanged;
		public event Action OnDeath;

		public bool IsDamagable { get; set; }
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
			MaxHealth *= DifficultyManager.playerHealthMultiplier;
			Debug.Log(MaxHealth);
			CurrentHealth = MaxHealth;
		}

		public void DealDamage(float amount)
		{
			if (!IsDamagable) return;

			CurrentHealth -= amount;

			if (CurrentHealth <= 0)
			{
				OnDeath?.Invoke();
			}

			OnHealthChanged?.Invoke(CurrentHealth);
		}

		public void HealHealth(float amount)
		{
			CurrentHealth += amount;

			CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

			OnHealthChanged?.Invoke(CurrentHealth);
		}

		public void ApplyEffect(IEffect effect)
		{
			if (!IsEffectable) return;
			effect.Init(gameObject);
			if (!effect.IsStackable && Effects.Count > 0) return;

			var effectCoroutine = StartCoroutine(effect.Effect(Effects));
			Effects.Enqueue(effectCoroutine);
		}

		private void Death()
		{
			Debug.Log("Player Died :(");
			Destroy(gameObject);
		}
	}
}
