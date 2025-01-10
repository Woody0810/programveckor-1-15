using System;
using UnityEngine;

namespace Health_Scripts.Modules
{
	public class LogHealth : MonoBehaviour
	{
		private Health _health;

		private void Awake()
		{
			_health = GetComponent<Health>();
		}

		private void OnEnable()
		{
			_health.OnHealthChanged += LogHealthText;
		}

		private void OnDisable()
		{
			_health.OnHealthChanged -= LogHealthText;
		}

		private void LogHealthText(float currentHealth)
		{
			Debug.Log($"Health: {currentHealth}");
		}
	}
}
