using System.Collections;
using Enemy.Base;
using UnityEngine;
using Weapon.Interfaces;

namespace Enemy.State_Machine.ConcreteStates
{
	public class EnemyAttackState : EnemyState
	{
		private Transform _playerTarget;
		private GameObject _bullet;

		private float _timeBetweenShots = 0.75f;
		private float _timer;

		public EnemyAttackState(BaseEnemy enemy, EnemyStateMachine stateMachine, GameObject bullet) : base(enemy, stateMachine)
		{
			_playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
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

				var direction = (_playerTarget.position - Enemy.transform.position).normalized * Enemy.EnemyProjectileSpeed;
				var bullet = GameObject.Instantiate(_bullet, Enemy.transform.position, Quaternion.identity).GetComponent<IProjectile>();
				bullet.Init();
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
