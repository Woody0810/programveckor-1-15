using EnemyScripts.Base;
using UnityEngine;
using Weapon.Interfaces;

namespace EnemyScripts.State_Machine.ConcreteStates
{
	public class EnemyAttackState : EnemyState
	{
		private GameObject _bullet;

		private float _timeBetweenShots = 1.5f;
		private float _timer;
		private IProjectile _projectile;

		public EnemyAttackState(BaseEnemy enemy, EnemyStateMachine stateMachine, GameObject bullet) : base(enemy, stateMachine)
		{
			_bullet = bullet;
		}

		public override void EnterState()
		{
			base.EnterState();

			_timer = _timeBetweenShots;
		}

		public override void ExitState()
		{
			base.ExitState();
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();

			if (!Enemy.IsAttacking)
			{
				Enemy.EnemyStateMachine.ChangeState(Enemy.IdleState);
				return;
			}

			Enemy.SetVelocity(Vector2.zero);

			if (_timer > _timeBetweenShots)
			{
				_timer = 0;

				var direction = (Enemy.PlayerTarget.transform.position - Enemy.transform.position).normalized;
				var bullet = GameObject.Instantiate(_bullet, Enemy.transform.position, Quaternion.identity).GetComponent<IProjectile>();
				bullet.SetVelocity(direction);
			}
			else
			{
				_timer += Time.deltaTime;
			}
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
	}
}
