using Enemy.Base;

namespace Enemy.State_Machine
{
	public class EnemyState
	{
		protected EnemyBase Enemy;
		protected EnemyStateMachine EnemyStateMachine;

		public EnemyState(EnemyBase enemy, EnemyStateMachine enemyStateMachine)
		{
			Enemy = enemy;
			EnemyStateMachine = enemyStateMachine;
		}

		public virtual void EnterState() {}
		public virtual void ExitState() {}
		public virtual void FrameUpdate() {}
		public virtual void PhysicsUpdate() {}
	}
}
