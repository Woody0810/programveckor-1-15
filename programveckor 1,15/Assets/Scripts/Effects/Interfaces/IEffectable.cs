using System.Collections.Generic;
using UnityEngine;

namespace Effects.Interfaces
{
	public interface IEffectable
	{
		Queue<Coroutine> Effects { get; set; }
		void ApplyEffect(IEffect effect);
	}
}
