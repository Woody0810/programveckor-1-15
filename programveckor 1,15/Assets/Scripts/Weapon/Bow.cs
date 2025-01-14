using System;
using System.Collections;
using System.Threading;
using Player;
using UnityEngine;
using Weapon.Interfaces;
using Weapon.Projectiles;

namespace Weapon
{
	public class Bow : MonoBehaviour, IWeapon
	{
		[SerializeField] private GameObject bullet;
		[SerializeField] private Vector2 fireDirection;
		[SerializeField] private Transform firePostion;

		[field: SerializeField] public float AttackSpeed { get; set; }
		[field: SerializeField] public float Damage { get; set; }
		public float Arrowreturn;

		private bool _canFire = true;
		private Vector3 _parentScale;
		private Quiver _quiver;
	
		private void Start()
		{
			_parentScale = GetComponentInParent<Transform>().localScale;
			_quiver = GetComponentInChildren<Quiver>();
		}

		private void Update()
		{
			Flip();

			if (Input.GetButtonDown("Fire1") && _canFire)
			{
				Attack();
			}
		}

		public void Attack()
		{
			var projectile = Instantiate(bullet, firePostion.position, Quaternion.identity).GetComponent<IProjectile>();
			projectile.Init(gameObject);
			projectile.SetVelocity(fireDirection);
			_quiver.DecreaseArrows();
			StartCoroutine(AttackDelay());
			StartCoroutine(Returnarrow());
		}

		public IEnumerator AttackDelay()
		{
			_canFire = false;
			yield return new WaitForSeconds(AttackSpeed);
			_canFire = true;
		}

		public IEnumerator Returnarrow()
		{
			yield return new WaitForSeconds(Arrowreturn);
			_quiver.IncreaseArrows();
		}

		private void Flip()
		{
			if (transform.localScale == _parentScale) return;
			transform.localScale = _parentScale;
		}
	}
}
