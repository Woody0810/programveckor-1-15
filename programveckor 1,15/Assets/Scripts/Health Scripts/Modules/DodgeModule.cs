using System.Collections;
using UnityEngine;

namespace Health_Scripts.Modules
{
	public class DodgeModule : MonoBehaviour
	{
		[SerializeField] private float invincibilityTimer;
		[SerializeField] private float dodgeTimer;

		private Health _health;
		private bool _canDodge = true;

		private void Start()
		{
			_health = GetComponent<Health>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.LeftControl))
			{
				StartCoroutine(StartDodge());
			}
		}

		private IEnumerator StartDodge()
		{
			if (!_canDodge) yield break;
			_health.IsDamagable(false);

			yield return new WaitForSeconds(invincibilityTimer);

			_health.IsDamagable(true);
			StartCoroutine(ResetDodgeTimer());
		}

		private IEnumerator ResetDodgeTimer()
		{
			_canDodge = false;
			yield return new WaitForSeconds(dodgeTimer);
			_canDodge = true;
		}
	}
}
