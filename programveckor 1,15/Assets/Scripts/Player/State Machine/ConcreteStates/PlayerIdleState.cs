using UnityEngine;

namespace Player.State_Machine.ConcreteStates
{
	public class PlayerIdleState : PlayerState
	{
		public PlayerIdleState(PlayerController player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
		{
		}

		public override void EnterState()
		{
			base.EnterState();

			Player.Rb.velocity = Vector2.zero;
		}

		public override void ExitState()
		{
			base.ExitState();
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();

			Player.CheckForPlayerMovement();

			if (Player.IsMoving)
			{
				Player.StateMachine.ChangeState(Player.MovingState);
			}

			if (Player.IsJumping)
			{
			}
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
	}
}
