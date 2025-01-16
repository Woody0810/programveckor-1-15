using System;
using Camera_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
	public class PlayerManager : MonoBehaviour
	{
		public static PlayerManager Instance { get; private set; }

		public PlayerHealth PlayerHealth { get; private set; }
		public PlayerController PlayerController { get; private set; }

		private void OnEnable()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		private void OnDisable()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		private void Awake()
		{
			if (Instance == null && Instance != this)
			{
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}

			PlayerHealth = GetComponent<PlayerHealth>();
			PlayerController = GetComponent<PlayerController>();
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			AssignCameraTarget();
		}

		private void AssignCameraTarget()
		{
			var cameraFollow = FindObjectOfType<CameraFollow>();
			cameraFollow.Target = transform;
		}
	}
}
