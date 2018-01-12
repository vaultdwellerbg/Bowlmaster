using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";

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
}
