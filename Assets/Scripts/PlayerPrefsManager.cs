using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string BALL_MODEL_KEY = "ball_model";
	const string TOP_SCORE_KEY = "top_score";

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

	#region ball model

	public static void SetBallModelIndex(int index)
	{
		PlayerPrefs.SetInt(BALL_MODEL_KEY, index);
	}

	public static int GetBallModelIndex()
	{
		return PlayerPrefs.GetInt(BALL_MODEL_KEY);
	}

	#endregion

	#region top score

	public static void SetTopScore(int value)
	{
		PlayerPrefs.SetInt(TOP_SCORE_KEY, value);
	}

	public static int GetTopScore()
	{
		return PlayerPrefs.GetInt(TOP_SCORE_KEY);
	}

	#endregion
}
