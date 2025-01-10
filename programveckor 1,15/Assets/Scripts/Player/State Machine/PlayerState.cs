using UnityEngine;

namespace Player.State_Machine
{
	public class PlayerState
	{
		protected PlayerController Player;
		protected PlayerStateMachine PlayerStateMachine;

		public PlayerState(PlayerController player, PlayerStateMachine playerStateMachine)
		{
			Player = player;
			PlayerStateMachine = playerStateMachine;
		}

		public virtual void EnterState() {}
		public virtual void ExitState() {}
		public virtual void FrameUpdate() {}
		public virtual void PhysicsUpdate() {}
	}
}
