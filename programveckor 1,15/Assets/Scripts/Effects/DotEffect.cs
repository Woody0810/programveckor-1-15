using System.Collections;
using System.Collections.Generic;
using Effects.Interfaces;
using Health_Scripts;
using UnityEngine;

namespace Effects
{
	public class DotEffect : MonoBehaviour, IEffect
	{
		[field: SerializeField] public bool IsStackable { get; set; }
		[SerializeField] private float damagePerTick;
		[SerializeField] private float tick;
		[SerializeField] private float totalTime;

		private Health _health;

		public void Init(GameObject effectableObject)
		{
			_health = effectableObject.GetComponent<Health>();
		}

		public IEnumerator Effect(Queue<Coroutine> effects = null)
		{
			var elapsedTime = 0f;

			while (elapsedTime < totalTime)
			{
				_health.DealDamage(damagePerTick);
				yield return new WaitForSeconds(tick);
				elapsedTime += tick;
			}

			if (effects?.Count > 0)
				StopCoroutine(effects.Dequeue());
		}
	}
}
