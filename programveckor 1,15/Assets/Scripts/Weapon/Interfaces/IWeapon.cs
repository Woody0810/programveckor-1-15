using System.Collections;

namespace Weapon.Interfaces
{
	public interface IWeapon
	{
		float AttackSpeed { get; set; }
		float Damage { get; set; }

		void Attack();
		IEnumerator AttackDelay();
	}
}
