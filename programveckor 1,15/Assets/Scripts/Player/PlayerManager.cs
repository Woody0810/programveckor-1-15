using System;
using UnityEngine;

namespace Player
{
	public class PlayerManager : MonoBehaviour
	{
		public static PlayerManager Instance { get; private set; }

		public PlayerHealth PlayerHealth { get; private set; }
		public PlayerController PlayerController { get; private set; }

		private void Awake()
		{
			if (Instance == null && Instance != this)
			{
				Instance = this;
			}
			else
			{
				Destroy(gameObject);
			}

			PlayerHealth = GetComponent<PlayerHealth>();
			PlayerController = GetComponent<PlayerController>();
		}
	}
}
