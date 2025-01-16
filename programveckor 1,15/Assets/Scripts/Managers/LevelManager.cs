using System;
using UnityEngine;

namespace Managers
{
	public class LevelManager : MonoBehaviour
	{
		public static LevelManager Instance { get; private set; }

		public bool CompletedLevel { get; set; }

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
		}
	}
}
