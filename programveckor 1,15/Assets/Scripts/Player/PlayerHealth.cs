using System;
using System.Collections.Generic;
using Effects.Interfaces;
using Health_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Player
{
	
	[Serializable]
	public class PlayerHealth : MonoBehaviour, IHealth, IEffectable
	{
        [field: SerializeField] public float MaxHealth { get; set; }
		public float CurrentHealth { get; set; }
		public Queue<Coroutine> Effects { get; set; }

		public bool IsDamagable { get; set; } = true;
		public bool IsEffectable { get; set; } = true;

		public event Action<float> OnHealthChanged;
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
			Effects = new Queue<Coroutine>();
		}

		public void TakeDamage(float amount)
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

		public void ApplyEffect(IEffect effect)
		{
			if (!IsEffectable) return;
			effect.Init(gameObject);
			if (!effect.IsStackable && Effects.Count >= 1) return;

			Effects.Enqueue(StartCoroutine(effect.Effect(Effects)));
		}

		private void Death()
		{
			Debug.Log("Player Died :(");
			Destroy(gameObject);
			SceneManager.LoadScene("You Lose");
		}
	}
}
