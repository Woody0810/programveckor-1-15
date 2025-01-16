using System;
using Enemy.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.TriggerChecks
{
	public class ChasingTriggerCheck : MonoBehaviour
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
			if (other.gameObject == _player && _enemy.CanChase)
			{
				_enemy.SetIsAggroed(true);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject == _player)
			{
				_enemy.SetIsAggroed(false);
			}
		}
	}
}
