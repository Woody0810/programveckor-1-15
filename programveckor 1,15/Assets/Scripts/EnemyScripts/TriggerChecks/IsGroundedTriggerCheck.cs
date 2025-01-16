using EnemyScripts.Base;
using UnityEngine;

namespace EnemyScripts.TriggerChecks
{
	public class IsGroundedTriggerCheck : MonoBehaviour
	{
		[SerializeField] private LayerMask groundLayers;
		private BaseEnemy _enemy;

		private void Start()
		{
			_enemy = GetComponentInParent<BaseEnemy>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.layer == LayerMask.NameToLayer("Ground") ||
			    other.gameObject.layer == LayerMask.NameToLayer("One Way Platform")) _enemy.SetIsGrounded(true);
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject.layer == LayerMask.NameToLayer("Ground") ||
			    other.gameObject.layer == LayerMask.NameToLayer("One Way Platform")) _enemy.SetIsGrounded(false);
		}
	}
}
