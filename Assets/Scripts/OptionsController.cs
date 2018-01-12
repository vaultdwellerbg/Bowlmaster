using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public LevelManager levelManager;
	public Slider volumeSlider;
	public Slider difficultySlider;
	
	private PersistentMusic persistentMusic;
	private BallModelChooser ballModelChooser;

	void Start () 
	{
		persistentMusic = GameObject.FindObjectOfType<PersistentMusic>();
		ballModelChooser = GameObject.FindObjectOfType<BallModelChooser>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		ballModelChooser.selectedModelIndex = PlayerPrefsManager.GetBallModelIndex();
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
		PlayerPrefsManager.SetBallModelIndex(ballModelChooser.selectedModelIndex);
		levelManager.LoadLevel("Start");
	}
	
	public void SetDefaults()
	{
		volumeSlider.value = 1;
		difficultySlider.value = 2;
	}
	
	
}
