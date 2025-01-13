using System;
using Enemy.Base;
using UnityEngine;

namespace Enemy.TriggerChecks
{
	public class ChasingTriggerCheck : MonoBehaviour
	{
		[SerializeField] private GameObject player;
		private BaseEnemy _enemy;

		private void Start()
		{
			_enemy = GetComponentInParent<BaseEnemy>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject == player)
			{
				_enemy.SetIsAggroed(true);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject == player)
			{
				_enemy.SetIsAggroed(false);
			}
		}
	}
}
