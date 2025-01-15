using System;
using System.Collections.Generic;
using UnityEngine;

namespace Health_Scripts.Modules
{
	public class HurtObject : MonoBehaviour
	{
		[SerializeField] private float damageAmount;
		[SerializeField] private List<string> targetTags;

		private void OnCollisionEnter2D(Collision2D other)
		{
			foreach (var targetTag in targetTags)
			{
				if (!other.gameObject.CompareTag(targetTag)) continue;
				if (other.gameObject.TryGetComponent<IHealth>(out var health))
				{
					health.TakeDamage(damageAmount);
					Destroy(gameObject);
				}
			}

			Destroy(gameObject);
		}
	}
}
