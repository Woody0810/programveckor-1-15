using System;
using Enemy.Base;
using UnityEngine;

namespace Enemy.TriggerChecks
{
	public class AgainstLedgeTriggerCheck : MonoBehaviour
	{
		[SerializeField] private Transform ledgeDetector;
		[SerializeField] private LayerMask groundLayer;
		[SerializeField] private float raycastDistance;

		private BaseEnemy _enemy;

		private void Start()
		{
			_enemy = GetComponentInParent<BaseEnemy>();
		}

		private void Update()
		{
			_enemy.SetIsAgainstLedge(!Physics2D.Raycast(ledgeDetector.position, Vector2.down, raycastDistance, groundLayer));
		}
	}
}
