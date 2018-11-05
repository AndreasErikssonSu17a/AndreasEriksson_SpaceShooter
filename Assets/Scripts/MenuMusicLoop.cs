using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicLoop : MonoBehaviour
{
	private AudioSource _audioSource;
	private void Start()
	{
		DontDestroyOnLoad(transform.gameObject);	//Musikobjektet försvinner aldrig så man kan alltid spela upp musiken i en enda loop mellan scener.

		_audioSource = GetComponent<AudioSource>();
	}

	//Startar musiken.
	public void PlayMusic()
	{
		if (_audioSource.isPlaying) return;

		_audioSource.Play();
	}

	//Stoppar musiken.
	public void StopMusic()
	{
		_audioSource.Stop();
	}
}
