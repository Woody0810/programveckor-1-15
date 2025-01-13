using System;
using Enemy.State_Machine;
using Enemy.State_Machine.ConcreteStates;
using UnityEngine;

namespace Enemy.Base
{
	public class BaseEnemy : MonoBehaviour
	{
		public EnemyHealth EnemyHealth { get; private set; }
		public Rigidbody2D Rb { get; private set; }
		public bool IsAgainstWall { get; private set; }

		[field: SerializeField] public float EnemyChaseSpeed { get; private set; }

		public bool IsFacingLeft { get; set; } = true;
		public bool IsAggroed { get; set; }
		public bool IsAttacking { get; set; }

		#region State Machine Variables

		public EnemyStateMachine EnemyStateMachine { get; set; }
		public EnemyIdleState IdleState { get; set; }
		public EnemyChasingState ChasingState { get; set; }
		public EnemyAttackState AttackState { get; set; }

		#endregion

		private void Start()
		{
			Rb = GetComponent<Rigidbody2D>();

			EnemyStateMachine = new EnemyStateMachine();
			IdleState = new EnemyIdleState(this, EnemyStateMachine);
			ChasingState = new EnemyChasingState(this, EnemyStateMachine);
			AttackState = new EnemyAttackState(this, EnemyStateMachine);

			EnemyStateMachine.Init(IdleState);
		}

		private void Update()
		{
			EnemyStateMachine.CurrentEnemyState.FrameUpdate();
		}

		private void FixedUpdate()
		{
			EnemyStateMachine.CurrentEnemyState.PhysicsUpdate();
		}

		public void SetVelocity(Vector2 newVelocity)
		{
			Rb.velocity = newVelocity;
			Flip(newVelocity);
		}

		public void Flip(Vector2 newVelocity)
		{
			if (IsFacingLeft && newVelocity.x > 0 || !IsFacingLeft && newVelocity.x < 0)
			{
				var localScale = transform.localScale;
				IsFacingLeft = !IsFacingLeft;
				localScale.x *= -1;
				transform.localScale = localScale;
			}
		}

		public virtual void Death() {}

		public void SetIsAgainstWall(bool isAgainstWall)
		{
			IsAgainstWall = isAgainstWall;
		}

		public void SetIsAggroed(bool isAggroed)
		{
			IsAggroed = isAggroed;
		}
	}
}
