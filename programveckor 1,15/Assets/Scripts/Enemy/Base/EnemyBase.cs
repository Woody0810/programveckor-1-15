using System;
using Enemy.Interfaces;
using Enemy.State_Machine;
using Enemy.State_Machine.ConcreteStates;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy.Base
{
	public class EnemyBase : MonoBehaviour, IEnemyMovable
	{
		public Rigidbody2D Rb { get; set; }
		public EnemyHealth EnemyHealth { get; private set; }
		public bool IsFacingRight { get; set; } = true;

		#region State Machine

		public EnemyStateMachine StateMachine { get; set; }

		public EnemyIdleState IdleState { get; set; }
		public EnemyChaseState ChaseState { get; set; }
		public EnemyAttackState AttackState { get; set; }

		#endregion

		#region Idle Variables

		public Transform[] points;

		#endregion

		private void Awake()
		{
			StateMachine = new EnemyStateMachine();

			IdleState = new EnemyIdleState(this, StateMachine);
			ChaseState = new EnemyChaseState(this, StateMachine);
			AttackState = new EnemyAttackState(this, StateMachine);
		}

		private void Start()
		{
			EnemyHealth = GetComponent<EnemyHealth>();
			Rb = GetComponent<Rigidbody2D>();

			StateMachine.Init(IdleState);
		}

		private void Update()
		{
			StateMachine.CurrentEnemyState.FrameUpdate();
		}

		private void FixedUpdate()
		{
			StateMachine.CurrentEnemyState.PhysicsUpdate();
		}

		public void SetVelocity(Vector2 velocity)
		{
			Rb.velocity = velocity;
			Flip(velocity);
		}

		public void Flip(Vector2 velocity)
		{
			if (IsFacingRight && velocity.x < 0f || !IsFacingRight && velocity.x > 0f)
			{
				var localScale = transform.localScale;
				IsFacingRight = !IsFacingRight;
				localScale.x *= -1;
				transform.localScale = localScale;
			}
		}
	}
}
