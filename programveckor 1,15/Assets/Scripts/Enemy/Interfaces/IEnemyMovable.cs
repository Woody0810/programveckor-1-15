using UnityEngine;

namespace Enemy.Interfaces
{
	public interface IEnemyMovable
	{
		Rigidbody2D Rb { get; set; }
		bool IsFacingRight { get; set; }

		void SetVelocity(Vector2 velocity);
		void Flip(Vector2 velocity);
	}
}
