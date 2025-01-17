using System;
using UnityEngine;

namespace Managers
{
	public class SpawnPointManager : MonoBehaviour
	{
		public Transform spawnPoint;

		private void Start()
		{
			var playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

			if (playerTransform.position != spawnPoint.position)
			{
				playerTransform.position = spawnPoint.position;
			}
		}
	}
}
