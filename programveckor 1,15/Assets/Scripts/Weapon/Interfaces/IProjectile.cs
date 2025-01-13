using UnityEngine;

namespace Weapon.Interfaces
{
	public interface IProjectile
	{
		void Init(GameObject creator = null);
		void SetVelocity(Vector2 newVelocity);
	}
}
