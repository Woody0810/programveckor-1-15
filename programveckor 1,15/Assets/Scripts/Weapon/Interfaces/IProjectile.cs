using UnityEngine;

namespace Weapon.Interfaces
{
	public interface IProjectile
	{
		void Init(GameObject creator);
		void SetVelocity(Vector2 newVelocity);
	}
}
