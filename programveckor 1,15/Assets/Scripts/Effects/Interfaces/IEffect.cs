using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects.Interfaces
{
	public interface IEffect
	{
		bool IsStackable { get; }
		void Init(GameObject effectableObject);
		IEnumerator Effect(Queue<Coroutine> stacks = null);
		void ClearEffect();
	}
}
