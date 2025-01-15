using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OneWayPlatform : MonoBehaviour
{
	[SerializeField] private Collider2D playerCollider;
	private GameObject _currentPlatform;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			if (_currentPlatform != null)
			{
				StartCoroutine(DisableCollisions());
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("OneWayPlatform"))
		{
			Debug.Log("Got here");
			_currentPlatform = other.gameObject;
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("OneWayPlatform"))
		{
			_currentPlatform = null;
		}
	}

	private IEnumerator DisableCollisions()
	{
		var platformCollider = _currentPlatform.GetComponent<CompositeCollider2D>();

		Physics2D.IgnoreCollision(playerCollider, platformCollider);
		yield return new WaitForSeconds(1);
		Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
	}
}
