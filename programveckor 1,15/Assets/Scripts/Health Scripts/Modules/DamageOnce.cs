using System;
using UnityEngine;

namespace Health_Scripts.Modules
{
	public class DamageOnce : MonoBehaviour
	{
		[SerializeField] private IHealth health;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Y))
			{
				health.DealDamage(10);
			}
		}
	}
}
