using System;
using Player;
using TMPro;
using UnityEngine;

namespace Health_Scripts.Modules
{
	public class HealthText : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI healthText;

		private PlayerHealth _playerHealth;

		private void Awake()
		{
			_playerHealth = GetComponent<PlayerHealth>();
		}

		private void OnEnable()
		{
			_playerHealth.OnHealthChanged += UpdateHealthText;
		}

		private void OnDisable()
		{
			_playerHealth.OnHealthChanged -= UpdateHealthText;
		}

		private void UpdateHealthText(float currentHealth)
		{
			healthText.text = $"Health: {currentHealth}";
		}
	}
}
