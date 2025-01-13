using System;
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
		}
	}
}
