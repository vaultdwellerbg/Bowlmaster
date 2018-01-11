using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string LEVEL_KEY = "level_unlocked";
	const string DIFFICULTY_KEY = "difficulty";	

	#region master volume

	public static void SetMasterVolume(float volume)
	{
		if (volume >= 0f && volume <= 1f)
		{
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else
		{
			Debug.LogError("Volume should be between 0 and 1");
		}
	}
	
	public static float GetMasterVolume()
	{
		float volume = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
		return (volume == 0f) ? 1f : volume;
	}
	
	#endregion
	
	#region unlock level
	public static void SetUnlockedLevel(int level)
	{
		PlayerPrefs.SetInt(LEVEL_KEY, level);
	}
	
	public static int GetUnlockedLevel()
	{	
		return PlayerPrefs.GetInt(LEVEL_KEY);
	}
	
	#endregion
	
	#region difficulty
	
	public static void SetDifficulty(int difficulty)
	{
		if(difficulty >= 1 && difficulty <= 3)
		{
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
		}
		else
		{
			Debug.LogError("Difficulty out of range (1 - 3)");
		}
	}
	
	public static int GetDifficulty()
	{
		int difficulty = PlayerPrefs.GetInt(DIFFICULTY_KEY);
		return (difficulty == 0) ? 2 : difficulty;
	}
	
	#endregion
}
