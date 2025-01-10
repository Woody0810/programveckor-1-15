using Enemy.Base;
using UnityEngine;

namespace Enemy.State_Machine.ConcreteStates
{
	public class EnemyChaseState : EnemyState
	{
		public EnemyChaseState(EnemyBase enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
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
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
	}
}
