using Enemy.Base;
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

			if (!Enemy.IsAggroed)
			{
				StateMachine.ChangeState(Enemy.IdleState);
				return;
			}

			if (Enemy.IsAttacking)
			{
				StateMachine.ChangeState(Enemy.AttackState);
				return;
			}

			if (Enemy.PlayerTarget.transform.position.y < Enemy.transform.position.y || Enemy.IsAgainstLedge)
			{
				Enemy.SetCanChase(false);
				StateMachine.ChangeState(Enemy.IdleState);
				return;
			}

			_direction = (Enemy.PlayerTarget.transform.position - Enemy.transform.position).normalized;
			_direction.y = 0;
			_direction.x *= Enemy.EnemyChaseSpeed;

			Enemy.EnemyAnimator.SetFloat("Horizontal", Mathf.Abs(_direction.x));
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();

			Enemy.SetVelocity(_direction);
		}
	}
}
