using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public LevelManager levelManager;
	public Slider volumeSlider;
	public Slider difficultySlider;
	
	private PersistentMusic persistentMusic;

	void Start () 
	{
		persistentMusic = GameObject.FindObjectOfType<PersistentMusic>();

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	void Update () 
	{
		if (persistentMusic)
		{
			persistentMusic.SetVolume(volumeSlider.value);
		}
	}
	
	public void SaveAndExit()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty((int)difficultySlider.value);
		levelManager.LoadLevel("Start");
	}
	
	public void SetDefaults()
	{
		volumeSlider.value = 1;
		difficultySlider.value = 2;
	}
	
	
}
