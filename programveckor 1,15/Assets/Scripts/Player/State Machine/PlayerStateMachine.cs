﻿namespace Player.State_Machine
{
	public class PlayerStateMachine
	{
		public PlayerState CurrentPlayerState { get; set; }

		public void Init(PlayerState startingState)
		{
			CurrentPlayerState = startingState;
			CurrentPlayerState.EnterState();
		}

		public void ChangeState(PlayerState newState)
		{
			CurrentPlayerState.ExitState();
			CurrentPlayerState = newState;
			CurrentPlayerState.EnterState();
		}
	}
}
