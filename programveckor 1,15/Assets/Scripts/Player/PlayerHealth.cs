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
	public class PlayerHealth : MonoBehaviour, IHealth
	{
        [field: SerializeField] public float MaxHealth { get; set; }
		public float CurrentHealth { get; set; }

		public bool IsDamagable { get; set; } = true;
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
            CurrentHealth *= PlayerPrefs.GetFloat("PlayerHealthMultiplier");
            Debug.Log("CurrentHealth " + CurrentHealth);
            Debug.Log("difficaulty " + PlayerPrefs.GetFloat("PlayerHealthMultiplier"));

            OnHealthChanged?.Invoke(CurrentHealth);
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

		private void Death()
		{
			Debug.Log("Player Died :(");
			Destroy(gameObject);
			SceneManager.LoadScene("You Lose");
		}

        AudioManager audioManager;
        private void Awake()
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }

        private void Update()
        {
            if (CurrentHealth < 20)
			{
                audioManager.PlaySFX(audioManager.heartbeat);
                Debug.Log("below 20 health :(");
            }
        }

    }
}
