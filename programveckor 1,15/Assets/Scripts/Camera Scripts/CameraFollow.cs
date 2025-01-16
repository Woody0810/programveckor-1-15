using System;
using UnityEngine;

namespace Camera_Scripts
{
	public class CameraFollow : MonoBehaviour
	{
		public Transform Target { get; set; }
		public Vector3 offset;
		public float smoothSpeed = 0.03f;

		private Vector3 _velocity = Vector3.zero;

		private void FixedUpdate()
		{
			if (!Target) return;

			var desiredPosition = Target.position + offset;
			transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, smoothSpeed);
		}
	}
}
