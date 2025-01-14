using System;
using UnityEngine;
using UnityEngine.Serialization;
using Weapon.Interfaces;

namespace Weapon.Projectiles
{
	public class Arrow : MonoBehaviour, IProjectile
	{
		#region Inspector Variables

		[SerializeField] private bool isAffectedByGravity;
		[SerializeField] private float speed;

		#endregion

		#region Private variable references

		private Rigidbody2D _rb;

		#endregion

		private void Awake()
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
			newVelocity *= speed;
			_rb.velocity = newVelocity;
		}
	}
}
