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

			Debug.Log("Enemy is idle");
			_newVelocity = Enemy.IsFacingLeft ? new Vector2(-1 * 4, 0) : new Vector2(1 * 4, 0);
			Enemy.SetVelocity(_newVelocity);
		}

		public override void ExitState()
		{
			base.ExitState();

			Debug.Log("Enemy is not idle");
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
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();

			Enemy.SetVelocity(_newVelocity);
		}
	}
}
