using EnemyScripts.Base;

namespace EnemyScripts.State_Machine
{
	public class EnemyState
	{
		protected BaseEnemy Enemy;
		protected EnemyStateMachine StateMachine;

		public EnemyState(BaseEnemy enemy, EnemyStateMachine stateMachine)
		{
			Enemy = enemy;
			StateMachine = stateMachine;
		}

		public virtual void EnterState() { }
		public virtual void ExitState() { }
		public virtual void FrameUpdate() { }
		public virtual void PhysicsUpdate() { }
	}
}
