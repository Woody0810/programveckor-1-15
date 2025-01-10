using System;
using Effects.Interfaces;
using UnityEngine;

namespace Health_Scripts
{
	public class HurtPlayer : MonoBehaviour
	{
		[SerializeField] private GameObject player;
		private IEffect _effect;
		private IEffectable _effectable;

		private void Start()
		{
			_effectable = player.GetComponent<IEffectable>();
			_effect = GetComponent<IEffect>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				_effectable.ApplyEffect(_effect);
			}
		}
	}
}
