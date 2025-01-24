using System;
using UnityEngine;

public class RespawnOnColliderHit : MonoBehaviour
{
	[SerializeField] private Transform respawnPoint;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.transform.position = respawnPoint.position;
		}
	}
}
