﻿using System;
using Enemy;
using EnemyScripts.State_Machine;
using EnemyScripts.State_Machine.ConcreteStates;
using UnityEngine;
using Weapon.Interfaces;

namespace EnemyScripts.Base
{
	public class BaseEnemy : MonoBehaviour
	{
		[SerializeField] private GameObject bullet;
		[field: SerializeField] public GameObject PlayerTarget { get; set; }
		public EnemyHealth EnemyHealth { get; private set; }
		public Rigidbody2D Rb { get; private set; }

		[field: SerializeField] public float EnemyChaseSpeed { get; private set; }
		[field: SerializeField] public float EnemyProjectileSpeed { get; private set; }

		public bool IsAgainstWall { get; private set; }
		public bool IsAgainstLedge { get; private set; }
		public bool IsFacingLeft { get; set; } = true;
		public bool IsAggroed { get; set; }
		public bool IsAttacking { get; set; }
		public bool IsGrounded { get; set; }

		public Animator EnemyAnimator { get; set; }

		#region State Machine Variables

		public EnemyStateMachine EnemyStateMachine { get; set; }
		public EnemyIdleState IdleState { get; set; }
		public EnemyAttackState AttackState { get; set; }

		#endregion

		private void Awake()
		{
			if (PlayerTarget == null)
			{
				PlayerTarget = GameObject.FindGameObjectWithTag("Player");
			}
		}

		private void Start()
		{
            EnemyChaseSpeed *= PlayerPrefs.GetFloat("EnemySpeedMultiplier");
            EnemyAnimator = GetComponent<Animator>();
			Rb = GetComponent<Rigidbody2D>();

			EnemyStateMachine = new EnemyStateMachine();
			IdleState = new EnemyIdleState(this, EnemyStateMachine);
			AttackState = new EnemyAttackState(this, EnemyStateMachine, bullet);

			EnemyStateMachine.Init(IdleState);
           

            // EnemyChaseSpeed *= DifficultyManager.enemySpeedMultiplier;
            // EnemyHealth.MaxHealth *= DifficultyManager.enemyHealthMultiplier;
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

		public void FireProjectile()
		{
			var direction = (PlayerTarget.transform.position - transform.position).normalized;
			var projectile = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<IProjectile>();
			projectile.SetVelocity(direction);
		}

		public void SetIsAgainstWall(bool isAgainstWall) => IsAgainstWall = isAgainstWall;

		public void SetIsAggroed(bool isAggroed) => IsAggroed = isAggroed;

		public void SetIsAttacking(bool isAttacking) => IsAttacking = isAttacking;

		public void SetIsGrounded(bool isGrounded) => IsGrounded = isGrounded;

		public void SetIsAgainstLedge(bool isAgainstLedge) => IsAgainstLedge = isAgainstLedge;
	}
}
