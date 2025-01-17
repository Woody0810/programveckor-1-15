using System;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Door
{

	public class Door : MonoBehaviour
	{
        AudioManager audioManager;

        private void Awake()
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }

        [SerializeField] private string sceneName;
		private bool _isInDoorRange;

		private void OnTriggerEnter2D(Collider2D other)
		{
			Debug.Log("Entered door range");
			_isInDoorRange = true;
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			Debug.Log("Left door range");
			_isInDoorRange = false;
		}

		private void Update()
		{
			if (_isInDoorRange && Input.GetKeyDown(KeyCode.E) && LevelManager.Instance.CompletedLevel)
			{
                audioManager.PlaySFX(audioManager.Bigpunch);
                SceneManager.LoadScene(sceneName);
			}
		}
	}
}
