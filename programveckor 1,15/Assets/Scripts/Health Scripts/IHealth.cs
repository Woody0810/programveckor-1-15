using System;

namespace Health_Scripts
{
	public interface IHealth
	{
		float MaxHealth { get; set; }
		float CurrentHealth { get; set; }

		public event Action<float> OnHealthChanged;
		public event Action OnDeath;

		public void TakeDamage(float amount);

		public void HealHealth(float amount);
	}
}
