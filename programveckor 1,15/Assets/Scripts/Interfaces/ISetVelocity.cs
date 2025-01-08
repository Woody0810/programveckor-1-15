using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Interfaces
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
