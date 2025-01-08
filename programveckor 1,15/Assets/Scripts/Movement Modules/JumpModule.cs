using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement_Modules
{
	public class JumpModule : MonoBehaviour
	{
		#region Inspector variables

		[SerializeField] private bool doubleJump;
		[SerializeField] private Vector2 boxSize;
		[SerializeField] private LayerMask groundMask;
		[SerializeField] private float castDistance;
		[SerializeField] private float jumpForce;
		[SerializeField] private float jumpDelay;

		#endregion

		#region Private variables

		private int _maxJumpCount;
		private int _jumpsLeft;
		private bool _firstJump = true;

		#endregion

		#region Private object references

		private Rigidbody2D _rb;

		#endregion

		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
			_maxJumpCount = doubleJump ? 2 : 1;
			_jumpsLeft = _maxJumpCount;
		}

		private void Update()
		{
			if (IsGrounded())
			{
				_jumpsLeft = _maxJumpCount;
				_firstJump = true;
			}

			if (Input.GetButtonDown("Jump") && _firstJump)
			{
				Jump();
			}

			if (_jumpsLeft > 0 && Input.GetButtonDown("Jump") && !_firstJump)
			{
				Jump();
			}
		}

		private void Jump()
		{
			_rb.velocity = new Vector2(_rb.velocity.x, 1 * jumpForce);
			_jumpsLeft--;
			_firstJump = false;
		}

		private bool IsGrounded()
		{
			return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundMask);
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
		}
	}
}
