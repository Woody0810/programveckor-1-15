using System;
using Enemy.Base;
using UnityEngine;

namespace Enemy.TriggerChecks
{
	public class IsGroundedTriggerCheck : MonoBehaviour
	{
		[SerializeField] private string groundTag;
		private BaseEnemy _enemy;

		private void Start()
		{
			_enemy = GetComponentInParent<BaseEnemy>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.CompareTag(groundTag)) _enemy.SetIsGrounded(true);
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject.CompareTag(groundTag)) _enemy.SetIsGrounded(false);
		}
	}
}
