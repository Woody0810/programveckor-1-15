﻿using Enemy.Base;
using UnityEngine;

namespace Enemy.State_Machine.ConcreteStates
{
	public class EnemyChasingState : EnemyState
	{
		private Vector2 _direction;

		public EnemyChasingState(BaseEnemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
		{
		}

		public override void EnterState()
		{
			base.EnterState();
		}

		public override void ExitState()
		{
			base.ExitState();
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();

			if (!Enemy.IsAggroed) StateMachine.ChangeState(Enemy.IdleState);
			if (Enemy.IsAttacking) StateMachine.ChangeState(Enemy.AttackState);

			_direction = (Enemy.PlayerTarget.transform.position - Enemy.transform.position).normalized;
			_direction.y = 0;
			_direction.x *= Enemy.EnemyChaseSpeed;
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();

			Enemy.SetVelocity(_direction);
		}
	}
}
