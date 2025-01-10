using System;
using UnityEngine;

namespace Movement.Modules
{
	public class WallJumpModule : MonoBehaviour
	{
		#region Inspector variables

		[SerializeField] private Vector2 boxSize;
		[SerializeField] private float castDistance;
		[SerializeField] private LayerMask wallMask;
		[SerializeField] private Transform boxPosition;

		#endregion

		#region Private object references

		private Rigidbody2D _rb;

		#endregion

		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			if (IsAgainstRightWall())
			{
				_rb.velocity = new Vector2(0, 0.1f);
			}

			if (IsAgainstLeftWall())
			{
				_rb.velocity = new Vector2(0, 0.1f);
			}
		}

		private bool IsAgainstRightWall()
		{
			return Physics2D.BoxCast(transform.position, boxSize, 0, transform.right, castDistance, wallMask);
		}

		private bool IsAgainstLeftWall()
		{
			return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.right, castDistance, wallMask);
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(transform.position - transform.right * castDistance, boxSize);
		}
	}
}
