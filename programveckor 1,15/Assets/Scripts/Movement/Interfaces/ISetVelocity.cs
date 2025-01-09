using UnityEngine;

namespace Movement.Interfaces
{
	public interface ISetVelocity
	{
		/// <summary>
		/// Sets an objects velocity with a new one
		/// </summary>
		/// <param name="newVelocity">The new velocity of the object</param>
		void SetVelocity(Vector3 newVelocity);
	}
}
