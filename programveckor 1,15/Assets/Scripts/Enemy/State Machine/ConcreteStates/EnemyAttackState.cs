using System.Collections;
using Enemy.Base;
using UnityEngine;
using Weapon.Interfaces;

namespace Enemy.State_Machine.ConcreteStates
{
	public class EnemyAttackState : EnemyState
	{
		private GameObject _bullet;

		private float _timeBetweenShots = 0.75f;
		private float _timer;
		private IProjectile _projectile;

		public EnemyAttackState(BaseEnemy enemy, EnemyStateMachine stateMachine, GameObject bullet) : base(enemy, stateMachine)
		{
			_projectile = bullet.GetComponent<IProjectile>();
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

			Enemy.SetVelocity(Vector2.zero);

			if (!Enemy.IsAttacking) StateMachine.ChangeState(Enemy.ChasingState);

			if (_timer > _timeBetweenShots)
			{
				_timer = 0;

				var direction = (Enemy.PlayerTarget.transform.position - Enemy.transform.position).normalized * Enemy.EnemyProjectileSpeed;
				var bullet = GameObject.Instantiate(_bullet, Enemy.transform.position, Quaternion.identity);
				_projectile.SetVelocity(direction);
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
