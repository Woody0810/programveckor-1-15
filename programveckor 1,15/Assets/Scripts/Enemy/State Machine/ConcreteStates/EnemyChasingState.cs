using Enemy.Base;
using UnityEngine;

namespace Enemy.State_Machine.ConcreteStates
{
	public class EnemyChasingState : EnemyState
	{
		private Transform _playerTarget;
		private Vector2 _direction;

		public EnemyChasingState(BaseEnemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
		{
			_playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
		}

		public override void EnterState()
		{
			base.EnterState();

			Debug.Log("Enemy is in chasing state");
		}

		public override void ExitState()
		{
			base.ExitState();

			Debug.Log("Enemy is not in chasing state");
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();

			if (!Enemy.IsAggroed) StateMachine.ChangeState(Enemy.IdleState);
			_direction = (_playerTarget.position - Enemy.transform.position).normalized;
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
