using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[System.Serializable]
	public class Sound
	{
		public string name;
		public AudioClip clip;
	}

	// Need multiple audio sources for sounds because of the "variable pitch" feature (to avoid adrupt pitch override)
	[SerializeField]
	private AudioSource soundSourceA;

	[SerializeField]
	private AudioSource soundSourceB;

	[SerializeField]
	private AudioSource musicSource;

	[SerializeField]
	private List<Sound> sounds;

	[SerializeField]
	private List<Sound> tracks;

	private static AudioManager objectInstance;

	void Awake()
	{
		if (objectInstance == null)
		{
			objectInstance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void PlaySound(string name)
	{
		Sound sound = sounds.Find(x => x.name == name);

		if (sound == null)
		{
			Debug.Log($"Failed to play \"{name}\" sound.");
		}
		else if (sound.name == "flap")
		{
			soundSourceB.pitch = Random.Range(0.9f, 1.1f);
			soundSourceB.PlayOneShot(sound.clip);
		}
		else
		{
			soundSourceA.pitch = Random.Range(0.9f, 1.1f);
			soundSourceA.PlayOneShot(sound.clip);
		}
	}

	public void PlayMusic(string name)
	{
		Sound track = tracks.Find(x => x.name == name);

		if (track == null)
		{
			Debug.Log($"Failed to play \"{name}\" track.");
		}
		else
		{
			musicSource.clip = track.clip;
			musicSource.Play();
		}
	}
}
