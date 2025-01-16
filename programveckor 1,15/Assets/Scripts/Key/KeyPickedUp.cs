using System;
using Managers;
using UnityEngine;

namespace Key
{
	public class KeyPickedUp : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				LevelManager.Instance.CompletedLevel = true;
				Destroy(gameObject);
			}
		}
	}
}
