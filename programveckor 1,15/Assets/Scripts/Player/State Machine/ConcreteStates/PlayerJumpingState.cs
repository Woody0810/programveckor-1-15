using UnityEngine;

namespace Player.State_Machine.ConcreteStates
{
	public class PlayerJumpingState : PlayerState
	{
		public PlayerJumpingState(PlayerController player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
		{
		}

		public override void EnterState()
		{
			base.EnterState();
		}

		public override void ExitState()
		{
			base.ExitState();
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
	}
}
