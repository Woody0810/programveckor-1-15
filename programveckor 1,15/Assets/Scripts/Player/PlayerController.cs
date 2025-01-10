using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		#region Inspector variables

		[Header("Movement")]
		[SerializeField] private float moveSpeed;

		[Header("Jump")]
		[SerializeField] private int maxJumps;
		[SerializeField] private Vector2 jumpBoxSize;
		[SerializeField] private LayerMask groundMask;
		[SerializeField] private float jumpCastDistance;
		[SerializeField] private float jumpForce;
		[SerializeField] private float jumpDelay;

		[Header("Wall Jump")]
		[SerializeField] private Vector2 wallBoxSize;
		[SerializeField] private float wallCastDistance;
		[SerializeField] private float wallClimbSpeed;
		[SerializeField] private LayerMask wallMask;
		[SerializeField] private LayerMask climableWallMask;

		#endregion

		#region Private object references

		private Rigidbody2D _rb;

		#endregion

		#region Private variables

		/// <summary>
		/// The current x direction the player is moving in
		/// </summary>
		private float _directionX;

		private bool _jumpDelay;

		private int _jumpsLeft;

		#endregion

		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
			_jumpsLeft = maxJumps;
		}

		private void Update()
		{
			_directionX = Input.GetAxisRaw("Horizontal");

			if (IsGrounded() && !_jumpDelay)
			{
				_jumpsLeft = maxJumps;
			}

			if (IsAgainstWall())
			{
				_jumpsLeft = 1;
				_rb.velocity = new Vector2(0, 0.2f);
			}

			if (IsAgainstClimableWall())
			{
				var moveY = Input.GetAxisRaw("Vertical");
				_rb.velocity = new Vector2(_rb.velocity.x, moveY * wallClimbSpeed);
			}

			if (_jumpsLeft > 0 && Input.GetButtonDown("Jump"))
			{
				Jump();
			}
		}

		private void FixedUpdate()
		{
			_rb.velocity = new Vector2(_directionX * moveSpeed, _rb.velocity.y);
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

		#region Wall / Ground Checks

		private bool IsGrounded()
		{
			return Physics2D.BoxCast(transform.position, jumpBoxSize, 0, -transform.up, jumpCastDistance, groundMask);
		}

		private bool IsAgainstWall()
		{
			return Physics2D.BoxCast(transform.position, wallBoxSize, 0, transform.right, wallCastDistance, wallMask) ||
			       Physics2D.BoxCast(transform.position, wallBoxSize, 0, -transform.right, wallCastDistance, wallMask);
		}

		private bool IsAgainstClimableWall()
		{
			return Physics2D.BoxCast(transform.position, wallBoxSize, 0, transform.right, wallCastDistance, climableWallMask) ||
			       Physics2D.BoxCast(transform.position, wallBoxSize, 0, -transform.right, wallCastDistance, climableWallMask);
		}

		#endregion

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(transform.position - transform.up * jumpCastDistance, jumpBoxSize);
			Gizmos.DrawWireCube(transform.position - transform.right * wallCastDistance, wallBoxSize);
		}
	}
}
