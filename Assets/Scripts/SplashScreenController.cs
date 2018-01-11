using UnityEngine;
using System.Collections;

public class SplashScreenController : MonoBehaviour {

	public AudioClip introMusic;

	void Start () {
		Invoke("LoadStartScreen", 4.5f);
	}
	
	void LoadStartScreen()
	{
		GameObject.FindObjectOfType<LevelManager>().LoadNextLevel();
	}
}
