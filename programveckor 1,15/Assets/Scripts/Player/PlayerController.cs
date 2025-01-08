using System;
using Interfaces;
using Movement_Modules;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		#region Inspector variables

		[SerializeField] private float moveSpeed;

		#endregion

		#region Private object references

		private ISetVelocity _setVelocity;
		private Rigidbody2D _rb;

		#endregion

		#region Private variables

		/// <summary>
		/// The current x direction the player is moving in
		/// </summary>
		private float _directionX;

		#endregion

		private void Start()
		{
			_setVelocity = GetComponent<ISetVelocity>();
			_rb = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			_directionX = Input.GetAxisRaw("Horizontal");
		}

		private void FixedUpdate()
		{
			_setVelocity.SetVelocity(new Vector3(_directionX * moveSpeed, _rb.velocity.y));
		}
	}
}
