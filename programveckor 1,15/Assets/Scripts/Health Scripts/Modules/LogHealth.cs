using System;
using UnityEngine;

namespace Health_Scripts.Modules
{
	public class LogHealth : MonoBehaviour
	{
		private IHealth _health;

		private void Awake()
		{
			_health = GetComponent<IHealth>();
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
