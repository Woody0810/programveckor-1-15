using Movement.Interfaces;
using UnityEngine;

namespace Player.State_Machine.ConcreteStates
{
	public class PlayerMovingState : PlayerState
	{
		private Rigidbody2D _rb;
		private ISetVelocity _setVelocity;
		private float _moveX;

		public PlayerMovingState(PlayerController player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
		{
		}

		public override void EnterState()
		{
			base.EnterState();

			_rb = Player.Rb;
			_setVelocity = Player.SetVelocity;

			Debug.Log("Player is moving");
		}

		public override void ExitState()
		{
			base.ExitState();

			Debug.Log("PLayer is no longer moving");
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();

			Player.CheckForPlayerMovement();

			if (!Player.IsMoving)
			{
				Player.StateMachine.ChangeState(Player.IdleState);
			}

			_moveX = Input.GetAxisRaw("Horizontal");
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();

			_setVelocity.SetVelocity(new Vector3(_moveX * 4, _rb.velocity.y));
		}
	}
}
