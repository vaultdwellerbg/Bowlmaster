using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PersistentMusic : MonoBehaviour {

	public AudioClip[] audioClips;
	
	private AudioSource music;

	void Awake() 
	{
		GameObject.DontDestroyOnLoad(gameObject);
		music = GetComponent<AudioSource>();
		SetVolume(PlayerPrefsManager.GetMasterVolume());
		PlayClip(0);			
	}

	void PlayClip(int index)
	{
		music.Stop();
		music.clip = audioClips[index];		
		music.Play();		
	}

	private void Start()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		int index = scene.buildIndex;
		if (audioClips[index])
		{
			PlayClip(index);
		}
	}

	public void SetVolume(float volume)
	{
		music.volume = volume;
	}	
}
