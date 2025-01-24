using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OnVideoEnded : MonoBehaviour
{
	[SerializeField] private VideoPlayer videoPlayer;

	private void Start()
	{
		videoPlayer.loopPointReached += source =>
		{
			SceneManager.LoadScene("Scenes/main meny");
		};
	}
}
