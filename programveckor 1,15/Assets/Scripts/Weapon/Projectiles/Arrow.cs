using System;
using UnityEngine;
using Weapon.Interfaces;

namespace Weapon.Projectiles
{
	public class Arrow : MonoBehaviour, IProjectile
	{
		#region Inspector Variables

		[SerializeField] private bool isAffectedByGravity;
		[SerializeField] private float xSpeed;

		#endregion

		#region Private variable references

		private Rigidbody2D _rb;

		#endregion

		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
			if (!isAffectedByGravity) _rb.gravityScale = 0;
		}

		public void Init(GameObject creator)
		{
			transform.localScale = creator.transform.localScale;
		}

		public void SetVelocity(Vector2 newVelocity)
		{
			newVelocity.x *= xSpeed;
			_rb.velocity = newVelocity;
		}
	}
}
