using Enemy.Base;
using UnityEngine;

namespace Enemy.State_Machine.ConcreteStates
{
	public class EnemyAttackState : EnemyState
	{
		public EnemyAttackState(BaseEnemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
		{
		}


		public override void EnterState()
		{
			base.EnterState();

			Debug.Log("Enemy is in attack state");
		}

		public override void ExitState()
		{
			base.ExitState();

			Debug.Log("Enemy is not in attack state");
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
