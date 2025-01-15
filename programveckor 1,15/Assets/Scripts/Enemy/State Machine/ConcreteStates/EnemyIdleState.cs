using Enemy.Base;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy.State_Machine.ConcreteStates
{
	public class EnemyIdleState : EnemyState
	{
		private Vector2 _newVelocity;

		public EnemyIdleState(BaseEnemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
		{
		}

		public override void EnterState()
		{
			base.EnterState();

			_newVelocity = new Vector2(-1 * 4, 0);
		}

		public override void ExitState()
		{
			base.ExitState();
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();

			if (Enemy.IsAggroed)
			{
				StateMachine.ChangeState(Enemy.ChasingState);
			}

			if (Enemy.IsAgainstWall)
			{
				_newVelocity *= -1;
				Enemy.SetIsAgainstWall(false);
			}

			if (Enemy.IsAgainstLedge && !Enemy.IsAgainstWall)
			{
				_newVelocity *= -1;
				Enemy.SetIsAgainstLedge(false);
			}

			Enemy.EnemyAnimator.SetFloat("Horizontal", Mathf.Abs(_newVelocity.x));
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();

			if (!Enemy.IsGrounded) return;

			Enemy.SetVelocity(_newVelocity);
		}
	}
}
