using System.Collections;
using UnityEngine;

namespace Movement.Modules
{
	public class JumpModule : MonoBehaviour
	{
		#region Inspector variables

		[SerializeField] private int maxJumps;
		[SerializeField] private Vector2 boxSize;
		[SerializeField] private LayerMask groundMask;
		[SerializeField] private float castDistance;
		[SerializeField] private float jumpForce;
		[SerializeField] private float jumpDelay;

		#endregion

		#region Private variables

		private int _maxJumpCount;
		private int _jumpsLeft;
		private bool _jumpDelay;

		#endregion

		#region Private object references

		private Rigidbody2D _rb;

		#endregion

		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
			_maxJumpCount = maxJumps;
			_jumpsLeft = _maxJumpCount;
		}

		private void Update()
		{
			if (IsGrounded() && !_jumpDelay)
			{
				_jumpsLeft = _maxJumpCount;
			}

			if (_jumpsLeft > 0 && Input.GetButtonDown("Jump"))
			{
				Jump();
			}
		}

		private IEnumerator JumpDelay()
		{
			yield return new WaitForSeconds(jumpDelay);
			_jumpDelay = false;
		}

		private void Jump()
		{
			_rb.velocity = new Vector2(_rb.velocity.x, 1 * jumpForce);
			_jumpsLeft--;
			_jumpDelay = true;
			StartCoroutine(JumpDelay());
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
