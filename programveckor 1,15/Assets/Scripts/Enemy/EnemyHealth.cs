using System;
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

		public void DealDamage(float amount)
		{
		}

		public void HealHealth(float amount)
		{
		}
	}
}
