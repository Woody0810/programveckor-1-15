using System;
using Enemy.Base;
using UnityEngine;

namespace Enemy.TriggerChecks
{
	public class AgainstWallTriggerCheck : MonoBehaviour
	{
		[SerializeField] private string wallTag;
		private BaseEnemy _enemy;

		private void Start()
		{
			_enemy = GetComponentInParent<BaseEnemy>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag(wallTag))
			{
				_enemy.SetIsAgainstWall(true);
			}
		}
	}
}
