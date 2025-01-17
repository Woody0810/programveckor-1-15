using Effects.Interfaces;
using Player;
using UnityEngine;
using Weapon.Interfaces;

namespace Weapon.Projectiles
{
	public class SlimeSpit : MonoBehaviour, IProjectile
	{
		[SerializeField] private bool isAffectedByGravity;
		[SerializeField] private float speed;

		private Rigidbody2D _rb;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody2D>();
			if (!isAffectedByGravity) _rb.gravityScale = 0;
		}

		public void Init(GameObject creator = null) { }

		public void SetVelocity(Vector2 newVelocity)
		{
			newVelocity *= speed;
			_rb.velocity = newVelocity;
			Destroy(gameObject, 3);
		}
	}
}
