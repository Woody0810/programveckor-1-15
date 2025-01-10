using System;
using System.Collections.Generic;
using Effects.Interfaces;
using UnityEngine;

namespace Health_Scripts
{
	public class Health : MonoBehaviour, IEffectable
	{
		[field: SerializeField] private float MaxHealth { get; set; }
		public Queue<Coroutine> Effects { get; set; } = new();
		private float _currentHealth;
		private bool _isDamagable = true;

		#region Damage Events

		public event Action<float> OnHealthChanged;
		public event Action OnDeath;

		#endregion

		private void Start()
		{
			_currentHealth = MaxHealth;
		}

		#region Heal / Damage Functions

		public void DealDamage(float amount)
		{
			if (!_isDamagable) return;
			_currentHealth -= amount;

			if (_currentHealth <= 0)
			{
				OnDeath?.Invoke();
			}

			OnHealthChanged?.Invoke(_currentHealth);
		}

		public void HealHealth(float amount)
		{
			_currentHealth += amount;

			if (_currentHealth >= MaxHealth)
			{
				_currentHealth = MaxHealth;
			}

			OnHealthChanged?.Invoke(_currentHealth);
		}

		#endregion

		public void IsDamagable(bool damagable)
		{
			_isDamagable = damagable;
		}

		public void ApplyEffect(IEffect effect)
		{
			effect.Init(gameObject);

			if (!effect.IsStackable && Effects.Count > 0) return;

			var effectCoroutine = StartCoroutine(effect.Effect(Effects));
			Effects.Enqueue(effectCoroutine);
		}
	}
}
