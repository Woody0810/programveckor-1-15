using System;
using Interfaces;
using UnityEngine;

namespace Movement_Modules
{
	public class MoveRigidbody : MonoBehaviour, ISetVelocity
	{
		// Reference to the rigidbody
		private Rigidbody2D _rb;

		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
		}

		public void SetVelocity(Vector3 newVelocity)
		{
			_rb.velocity = newVelocity;
		}
	}
}
