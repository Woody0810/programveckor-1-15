using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Weapon
{
	public class Quiver : MonoBehaviour
	{
		[SerializeField] private int arrowsLeft;
		[SerializeField] private Sprite[] sprites;
		[SerializeField] private Image arrowImage;
		[SerializeField] private float arrowReturnDelay;

		private int _currentSpriteIndex;

		private void Start()
		{
			_currentSpriteIndex = arrowsLeft;
			UpdateSprite();
		}

		private void Update()
		{
			if (_currentSpriteIndex == arrowsLeft) return;

			UpdateSprite();
		}

		public void IncreaseArrows() => arrowsLeft++;

		public void DecreaseArrows()
		{
			arrowsLeft--;
			StartCoroutine(ReturnArrowAfterDelay());
		}

		public void UpdateSprite()
		{
			if (_currentSpriteIndex >= sprites.Length) _currentSpriteIndex = arrowsLeft;
			else if (_currentSpriteIndex <= 0) _currentSpriteIndex = 0;
			else _currentSpriteIndex = arrowsLeft;

			arrowImage.sprite = sprites[_currentSpriteIndex];
		}

		private IEnumerator ReturnArrowAfterDelay()
		{
			yield return new WaitForSeconds(arrowReturnDelay);
			IncreaseArrows();
		}
	}
}
