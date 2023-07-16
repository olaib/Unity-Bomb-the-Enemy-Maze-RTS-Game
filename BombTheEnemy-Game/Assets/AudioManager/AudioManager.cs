using System;
using UnityEngine;
using UnityEngine.Audio;
/**
*Audio manager class - singleton.
*Manages the audio clips and plays them.
*/
public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public Sound[] sounds;
	// Use this for initialization
	void Awake ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
	/*
	* Play the sound
	* @param sound - the name of the sound to play
	*/
	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
	}
	/**
	* Stop the sound
	* @param sound - the name of the sound to stop
	*/
	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Stop();
	}
}
