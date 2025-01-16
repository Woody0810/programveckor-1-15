using EnemyScripts.Base;
using UnityEngine;

namespace EnemyScripts.TriggerChecks
{
	public class AttackingTriggerCheck : MonoBehaviour
	{
		private GameObject _player;
		private BaseEnemy _enemy;

		private void Start()
		{
			_enemy = GetComponentInParent<BaseEnemy>();
			if (_player == null) _player = GameObject.FindGameObjectWithTag("Player");
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject == _player) _enemy.SetIsAttacking(true);
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject == _player) _enemy.SetIsAttacking(false);
		}
	}
}
