using System;
using Player;
using UnityEngine;
using Weapon.Interfaces;

namespace Weapon.Projectiles
{
	public class SlimeSpit : MonoBehaviour, IProjectile
	{
		private Rigidbody2D _rb;

		public void Init(GameObject creator = null)
		{
			_rb = GetComponent<Rigidbody2D>();
		}

		public void SetVelocity(Vector2 newVelocity)
		{
			_rb.velocity = newVelocity;
			Destroy(gameObject, 5);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				var pHealth = other.gameObject.GetComponent<PlayerHealth>();
				pHealth.DealDamage(10);
				Destroy(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
