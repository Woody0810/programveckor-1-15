using System;
using Movement.Interfaces;
using Player.State_Machine;
using Player.State_Machine.ConcreteStates;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		#region Inspector variables

		[SerializeField] private float moveSpeed;

		#endregion

		#region Private object references

		public ISetVelocity SetVelocity { get; private set; }
		public Rigidbody2D Rb { get; private set; }
		public PlayerStateMachine StateMachine { get; private set; }

		#endregion

		#region Private variables

		/// <summary>
		/// The current x direction the player is moving in
		/// </summary>
		private float _directionX;

		public bool IsGrounded { get; set; }
		public bool IsOnWall { get; set; }
		public bool IsOnClimableWall { get; set; }
		public bool IsJumping { get; set; }
		public bool IsMoving { get; set; }

		#endregion

		#region Player States

		public PlayerIdleState IdleState { get; private set; }
		public PlayerMovingState MovingState { get; private set; }

		#endregion

		private void Start()
		{
			StateMachine = new PlayerStateMachine();
			IdleState = new PlayerIdleState(this, StateMachine);
			MovingState = new PlayerMovingState(this, StateMachine);

			SetVelocity = GetComponent<ISetVelocity>();
			Rb = GetComponent<Rigidbody2D>();

			StateMachine.Init(IdleState);
		}

		private void Update()
		{
			StateMachine.CurrentPlayerState.FrameUpdate();
		}

		private void FixedUpdate()
		{
			StateMachine.CurrentPlayerState.PhysicsUpdate();
		}

		public void CheckForPlayerMovement()
		{
			IsMoving = Input.GetButtonDown("Horizontal");
		}

		public void CheckForPlayerJumping()
		{
			IsJumping = Input.GetButtonDown("Jump");
		}
	}
}
