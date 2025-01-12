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

		#endregion

		#region Private object references

		private Rigidbody2D _rb;
		private PlayerHealth _playerHealth;
		private Animator _animator;

		#endregion

		#region Wall Jump

		[Header("Wall Jump")]
		[SerializeField] private Vector2 wallBoxSize;
		[SerializeField] private float wallCastDistance;
		[SerializeField] private float wallClimbSpeed;
		[SerializeField] private LayerMask wallMask;
		[SerializeField] private LayerMask climableWallMask;

		#endregion

		#region Jump

		[Header("Jump")]
		[SerializeField] private int maxJumps;
		[SerializeField] private Vector2 jumpBoxSize;
		[SerializeField] private LayerMask groundMask;
		[SerializeField] private float jumpCastDistance;
		[SerializeField] private float jumpForce;
		[SerializeField] private float jumpDelay;

		private bool _isJumping;
		private int _remainingJumps;

		#endregion

		#region Private variables

		/// <summary>
		/// The current x direction the player is moving in
		/// </summary>
		private float _directionX;

		private float _moveY;

		public bool IsFacingLeft { get; private set; } = true;

		#endregion

		#region Dash

		private bool _canDash = true;
		private bool _isDashing;

		[Header("Dash")]
		[SerializeField] private float dashingPower;
		[SerializeField] private float dashingTime;
		[SerializeField] private float dashingCooldown;

		#endregion

		#region Animation

		private static readonly int Horizontal = Animator.StringToHash("Horizontal");

		#endregion

		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
			_playerHealth = GetComponent<PlayerHealth>();
			_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			if (_isDashing) return;

			_directionX = Input.GetAxisRaw("Horizontal");

			if (IsGrounded() && !Input.GetButton("Jump"))
			{
				_isJumping = false;
				_remainingJumps = maxJumps;
			}

			if (Input.GetButtonDown("Jump"))
			{
				if (IsGrounded() || (_isJumping && _remainingJumps > 0))
				{
					_isJumping = true;
					_rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
					_remainingJumps--;
				}
			}

			if (IsAgainstWall())
			{
				_remainingJumps = 1;
				_rb.velocity = new Vector2(0, -0.2f);
			}

			if (IsAgainstClimableWall())
			{
				_moveY = Input.GetAxisRaw("Vertical");
				_rb.velocity = new Vector2(_rb.velocity.x, _moveY * wallClimbSpeed);
			}

			if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
			{
				StartCoroutine(Dash());
			}

			_animator.SetFloat(Horizontal, Mathf.Abs(_directionX));

			Flip();
		}

		private void FixedUpdate()
		{
			if (_isDashing) return;
			_rb.velocity = new Vector2(_directionX * moveSpeed, _rb.velocity.y);
		}

		private void Flip()
		{
			if (IsFacingLeft && _directionX > 0f || !IsFacingLeft && _directionX < 0f)
			{
				var localScale = transform.localScale;
				IsFacingLeft = !IsFacingLeft;
				localScale.x *= -1;
				transform.localScale = localScale;
			}
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

		private IEnumerator Dash()
		{
			_canDash = false;
			_isDashing = true;
			var originalGravity = _rb.gravityScale;
			_rb.gravityScale = 0;
			_rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
			_playerHealth.IsDamagable = false;
			_playerHealth.IsEffectable = false;

			yield return new WaitForSeconds(dashingTime);

			_rb.gravityScale = originalGravity;
			_playerHealth.IsDamagable = true;
			_playerHealth.IsEffectable = true;
			_isDashing = false;

			yield return new WaitForSeconds(dashingCooldown);

			_canDash = true;
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(transform.position - transform.up * jumpCastDistance, jumpBoxSize);
			Gizmos.DrawWireCube(transform.position - transform.right * wallCastDistance, wallBoxSize);
		}
	}
}
