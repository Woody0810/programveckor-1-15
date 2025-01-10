using UnityEngine;

namespace Enemy.State_Machine
{
	public class EnemyStateMachine
	{
		public EnemyState CurrentEnemyState { get; set; }

		public void Init(EnemyState startingState)
		{
			CurrentEnemyState = startingState;
			CurrentEnemyState.EnterState();
		}

		public void ChangeState(EnemyState newState)
		{
			CurrentEnemyState.ExitState();
			CurrentEnemyState = newState;
			CurrentEnemyState.EnterState();
		}
	}
}
